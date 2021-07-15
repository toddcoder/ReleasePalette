using Core.Collections;
using Core.Matching;
using Core.Strings;

namespace ReleasePalette
{
   public class OutlookArguments
   {
      public OutlookArguments(string to, string otherTo, string cc, string subject, string body, string location)
      {
         To = to;
         OtherTo = otherTo;
         Cc = cc;
         Subject = subject;
         Body = body;
         Location = location;
      }

      public OutlookArguments(string to, string otherTo, string cc, string subject, string body) : this(to, otherTo, cc, subject, body, string.Empty)
      {
      }

      public string To { get; set; }

      public string OtherTo { get; set; }

      public string Cc { get; set; }

      public string Subject { get; set; }

      public string Body { get; set; }

      public string Location { get; set; }

      public void Format(AutoStringHash replacements)
      {
         replacements["otherTo"] = OtherTo;
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
         To = formatter.Format(To);
         Cc = formatter.Format(Cc);
         Subject = formatter.Format(Subject);
         Body = formatter.Format(Body);
         Location = formatter.Format(Location);
      }
   }
}