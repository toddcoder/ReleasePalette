using System;
using Microsoft.Office.Interop.Outlook;

namespace ReleasePalette
{
   public class OutlookMailItem : IOutlookItem
   {
      protected MailItem mailItem;

      public OutlookMailItem()
      {
         var application = new Application();
         mailItem = (MailItem)application.CreateItem(OlItemType.olMailItem);
         mailItem.BodyFormat = OlBodyFormat.olFormatHTML;

         StartDate = DateTime.MinValue;
         EndDate = DateTime.MinValue;
         Location = string.Empty;
      }

      public string To
      {
         get => mailItem.To;
         set => mailItem.To = value;
      }

      public string Cc
      {
         get => mailItem.CC;
         set => mailItem.CC = value;
      }

      public string Subject
      {
         get => mailItem.Subject;
         set => mailItem.Subject = value;
      }

      public string Body
      {
         get => mailItem.HTMLBody;
         set => mailItem.HTMLBody = value;
      }

      public DateTime StartDate { get; set; }

      public DateTime EndDate { get; set; }

      public string Location { get; set; }

      public void AddAttachment(string attachment) => mailItem.Attachments.Add(attachment);

      public void ResolveAll() => mailItem.Recipients.ResolveAll();

      public void AddSignature()
      {
         var _ = mailItem.GetInspector;
      }

      public void Display() => mailItem.Display(false);
   }
}