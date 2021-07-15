using System.IO;
using Core.Matching;
using Core.Strings;
using Markdig;
using Microsoft.Office.Interop.Outlook;

namespace ReleasePalette
{
   public class OutlookMailItem : IOutlookItem
   {
      protected MailItem mailItem;
      protected string body;

      public OutlookMailItem(OutlookArguments arguments)
      {
         var application = new Application();
         mailItem = (MailItem)application.CreateItem(OlItemType.olMailItem);
         mailItem.BodyFormat = OlBodyFormat.olFormatHTML;

         mailItem.To = arguments.To;
         mailItem.CC = arguments.Cc;
         mailItem.Subject = arguments.Subject;
         body = arguments.Body;
      }

      public void AddAttachment(string attachment) => mailItem.Attachments.Add(attachment);

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

      public void GenerateBody()
      {
         var pipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
         var htmlBody = Markdown.ToHtml(body, pipeline);
         htmlBody = removeH2(htmlBody);
         mailItem.HTMLBody = wrap(htmlBody);
      }

      public void ResolveAll() => mailItem.Recipients.ResolveAll();

      public void AddSignature()
      {
         var _ = mailItem.GetInspector;
      }

      public void Display() => mailItem.Display(false);
   }
}