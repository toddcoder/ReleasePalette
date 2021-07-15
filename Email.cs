using System.Collections.Generic;
using Core.Computers;
using Core.Monads;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class Email
   {
      protected Result<string> _to;
      protected string to;
      protected Maybe<string> _cc;
      protected Result<string> _subject;
      protected string subject;
      protected Result<string> _body;
      protected string body;
      protected List<string> attachments;

      public Email()
      {
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

      public virtual IOutlookItem GetOutlookItem() => new OutlookMailItem();

      protected virtual void checkArguments()
      {
         to = _to.ForceValue();
         subject = _subject.ForceValue();
         body = _body.ForceValue();
      }

      protected virtual void setArguments(IOutlookItem mailItem)
      {
         mailItem.To = to;
         if (_cc.If(out var cc))
         {
            mailItem.Cc = cc;
         }

         mailItem.Subject = subject;
      }

      public Result<Unit> Open()
      {
         try
         {
            checkArguments();

            var mailItem = GetOutlookItem();

            setArguments(mailItem);

            if (AddSignature)
            {
               mailItem.AddSignature();
               mailItem.Body = body + mailItem.Body;
            }
            else
            {
               mailItem.Body = body;
            }

            foreach (var attachment in attachments)
            {
               mailItem.AddAttachment(attachment);
            }

            mailItem.ResolveAll();
            mailItem.Display();

            return Unit.Success();

         }
         catch (System.Exception exception)
         {
            return failure<Unit>(exception);
         }
      }
   }
}