using System.Collections.Generic;
using Core.Assertions;
using Core.Computers;
using Core.Monads;
using Microsoft.Office.Interop.Outlook;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class Emailer
   {
      protected Application application;
      protected Result<string> _to;
      protected Maybe<string> _cc;
      protected Result<string> _subject;
      protected Result<string> _body;
      protected List<string> attachments;

      public Emailer()
      {
         application = new Application();

         _to = "To is required".Failure<string>();
         _cc = none<string>();
         _subject = "Subject is required".Failure<string>();
         _body = "Body is required".Failure<string>();
         AddSignature = true;
         attachments = new List<string>();
      }

      public string To
      {
         get => _to.ForceValue();
         set => _to = value.Success();
      }

      public string Cc
      {
         get => _cc.DefaultTo(() => string.Empty);
         set => _cc = value.Some();
      }

      public string Subject
      {
         get => _subject.ForceValue();
         set => _subject = value.Success();
      }

      public string Body
      {
         get => _body.ForceValue();
         set => _body = value.Success();
      }

      public bool AddSignature { get; set; }

      public void AddAttachment(FileName file) => attachments.Add(file.FullPath);

      public Result<Unit> Open()
      {
         try
         {
            var to = _to.Must().BeSuccessful().Force();
            var subject = _subject.Must().BeSuccessful().Force();
            var body = _body.Must().BeSuccessful().Force();

            var mailItem = (MailItem)application.CreateItem(OlItemType.olMailItem);
            mailItem.To = to;
            if (_cc.If(out var cc))
            {
               mailItem.CC = cc;
            }

            mailItem.Subject = subject;
            mailItem.BodyFormat = OlBodyFormat.olFormatHTML;

            if (AddSignature)
            {
               var _ = mailItem.GetInspector;
               mailItem.HTMLBody = body + mailItem.HTMLBody;
            }
            else
            {
               mailItem.HTMLBody = body;
            }

            foreach (var attachment in attachments)
            {
               mailItem.Attachments.Add(attachment);
            }

            mailItem.Recipients.ResolveAll();
            mailItem.Display(false);

            return Unit.Success();

         }
         catch (System.Exception exception)
         {
            return failure<Unit>(exception);
         }
      }
   }
}