using System;
using Core.Assertions;
using Core.Collections;
using Core.Computers;
using Core.Configurations;
using Core.Monads;
using Core.Strings;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class EmailGenerator
   {
      protected string source;

      public EmailGenerator(string source)
      {
         this.source = source;
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

      public Result<Unit> Generate(StringHash replacements, string[] attachments)
      {
         var formatter = new Formatter(replacements);

         string replace(string source) => formatter.Format(source);

         try
         {
            var _arguments =
               from configuration in getEmailConfiguration()
               from tuple in getArguments(configuration)
               select tuple;
            if (_arguments.If(out var to, out var cc, out var subject, out var body, out var exception))
            {
               to = replace(to);
               cc = replace(cc);
               subject = replace(subject);
               body = replace(body);

               var emailer = new Emailer { To = to, Cc = cc, Subject = subject, Body = body };
               foreach (var attachment in attachments)
               {
                  FileName attachmentFile = attachment;
                  attachmentFile.Must().Exist().OrThrow();
                  emailer.AddAttachment(attachmentFile);
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