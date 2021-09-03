using System;
using System.Collections.Generic;
using Core.Collections;
using Core.Computers;
using Core.Configurations;
using Core.Monads;
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

      protected virtual Result<OutlookArguments> getArguments(Configuration configuration)
      {
         return
            from to in configuration.GetValue("to").Result("'To' is required")
            from cc in configuration.GetValue("cc").DefaultTo(() => "").Success()
            from subject in configuration.GetValue("subject").Result("'Subject' is required")
            from body in configuration.GetValue("body").Result("'Body' is required")
            select new OutlookArguments(to, cc, subject, body, personal);
      }

      protected virtual IOutlookItem getOutlookItem(OutlookArguments arguments) => new OutlookMailItem(arguments);

      public Result<Unit> Generate(AutoStringHash replacements, IEnumerable<string> attachments)
      {
         try
         {
            var _arguments =
               from configuration in getEmailConfiguration()
               from outlookArguments in getArguments(configuration)
               select outlookArguments;
            if (_arguments.If(out var arguments, out var exception))
            {
               arguments.Format(replacements);
               var item = getOutlookItem(arguments);

               item.AddSignature();
               item.GenerateBody();

               foreach (var attachment in attachments)
               {
                  FileName attachmentFile = attachment;
                  if (attachmentFile.Exists())
                  {
                     item.AddAttachment(attachment);
                  }
               }

               item.ResolveAll();
               item.Display();

               return unit;
            }
            else
            {
               return exception;
            }
         }
         catch (Exception exception)
         {
            return exception;
         }
      }
   }
}