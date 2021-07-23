using Core.Collections;
using Core.Matching;
using Core.Strings;

namespace ReleasePalette
{
   public class OutlookArguments
   {
      public OutlookArguments(string to, string cc, string subject, string body, Personal personal)
      {
         To = to;
         Cc = cc;
         Subject = subject;
         Body = body;
         Personal = personal;
      }

      public OutlookArguments(string to, string cc, string subject, string body) : this(to, cc, subject, body, new Personal())
      {
      }

      public string To { get; set; }

      public string Cc { get; set; }

      public string Subject { get; set; }

      public string Body { get; set; }

      public Personal Personal { get; set; }

      public void Format(AutoStringHash replacements)
      {
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

         var outage = replacements["outageType"].Same("Outage") ? "YES" : "NO";
         replacements["database"] = outage;
         replacements["outage"] = outage;
         Personal.SetReplacements(replacements);

         var formatter = new Formatter(replacements);
         To = formatter.Format(To);
         Cc = formatter.Format(Cc);
         Subject = formatter.Format(Subject);
         Body = formatter.Format(Body);
      }
   }
}