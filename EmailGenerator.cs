using System;
using System.Collections.Generic;
using System.IO;
using Core.Collections;
using Core.Computers;
using Core.Configurations;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using Markdig;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class EmailGenerator
   {
      protected string source;
      protected Personal personal;

      public EmailGenerator(string source, Personal personal)
      {
         this.source = source;
         this.personal = personal;
      }

      protected Result<Configuration> getEmailConfiguration() => Configuration.FromString(source);

      protected static Result<(string to, string cc, string subject, string body)> getArguments(Configuration configuration)
      {
         return
            from to in configuration.GetValue("to").Result("'To' is required")
            from cc in configuration.GetValue("cc").DefaultTo(() => string.Empty).Success()
            from subject in configuration.GetValue("subject").Result("'Subject' is required")
            from body in configuration.GetValue("body").Result("'Body' is required")
            select (to, cc, subject, body);
      }

      protected static string removeH2(string html)
      {
         if (html.StartsWith("<h2>"))
         {
            var removed = html.Drop(4);
            if (removed.Matches("(</h2>)").If(out var result))
            {
               result.FirstGroup = string.Empty;
               return result.ToString();
            }
         }

         return html;
      }

      protected static string wrap(string html)
      {
         using var writer = new StringWriter();

         writer.WriteLine("<html><style>");
         writer.WriteLine("table {font-family: consolas; font-size: 12; border-collapse: collapse;}");
         writer.WriteLine("th, td {border: 1px solid; padding: 5px;}");
         writer.WriteLine("th {background-color: #dddddd; border-bottom: 2px solid}");
         writer.WriteLine("tr:nth-child(even) {background-color: #dddddd;}");
         writer.WriteLine("h2 {font-family: consolas; font-size: 12");
         writer.WriteLine("</style><body>");
         writer.WriteLine(html);
         writer.WriteLine("</body></html>");

         return writer.ToString();
      }

      public Result<Unit> Generate(StringHash replacements, IEnumerable<string> attachments)
      {
         replacements["otherTo"] = personal.OtherTo;
         replacements["notes-release"] = replacements["release"].Replace(".", "-");
         var pullRequestTitle = replacements["masterPrTitle"];
         if (pullRequestTitle.Matches(@"^(Pull Request \d+)(.+)$").If(out var result))
         {
            replacements["pullRequestTitle1"] = result.FirstGroup;
            replacements["pullRequestTitle2"] = result.SecondGroup;
         }
         else
         {
            replacements["pullRequestTitle2"] = pullRequestTitle;
         }

         replacements["tag"] = replacements["release"].Replace("r-", "v");

         var formatter = new Formatter(replacements);

         try
         {
            var _arguments =
               from configuration in getEmailConfiguration()
               from tuple in getArguments(configuration)
               select tuple;
            if (_arguments.If(out var to, out var cc, out var subject, out var body, out var exception))
            {
               to = formatter.Format(to);
               cc = formatter.Format(cc);
               subject = formatter.Format(subject);
               body = formatter.Format(body);

               var addSignature = personal.Signature.IsEmpty();

               if (!addSignature)
               {
                  body = $"{body}\r\n{personal.Signature}";
               }

               var pipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
               var htmlBody = Markdown.ToHtml(body, pipeline);
               htmlBody = removeH2(htmlBody);
               htmlBody = wrap(htmlBody);

               var emailer = new Emailer { To = to, Cc = cc, Subject = subject, Body = htmlBody, AddSignature = addSignature };
               foreach (var attachment in attachments)
               {
                  FileName attachmentFile = attachment;
                  if (attachmentFile.Exists())
                  {
                     emailer.AddAttachment(attachmentFile);
                  }
               }

               return emailer.Open();
            }
            else
            {
               return failure<Unit>(exception);
            }
         }
         catch (Exception exception)
         {
            return failure<Unit>(exception);
         }
      }
   }
}