using System;
using Microsoft.Office.Interop.Outlook;
using Core.Matching;

namespace ReleasePalette
{
   public class OutlookAppointmentItem : IOutlookItem
   {
      protected AppointmentItem mailItem;

      public OutlookAppointmentItem()
      {
         var application = new Application();
         mailItem = (AppointmentItem)application.CreateItem(OlItemType.olAppointmentItem);
         mailItem.ReminderSet = true;
         mailItem.ReminderMinutesBeforeStart = 15;
         mailItem.BusyStatus = OlBusyStatus.olBusy;

         Cc = string.Empty;
         StartDate = DateTime.MinValue;
         EndDate = DateTime.MinValue;
         Location = string.Empty;
      }

      public string To
      {
         get => mailItem.Recipients.ToString();
         set
         {
            foreach (var recipient in value.Split(@"\s*;\s*"))
            {
               mailItem.Recipients.Add(recipient);
            }
         }
      }

      public string Cc { get; set; }

      public string Subject
      {
         get => mailItem.Subject;
         set => mailItem.Subject = value;
      }

      public string Body { get; set; }

      public DateTime StartDate
      {
         get => mailItem.Start;
         set => mailItem.Start = value;
      }

      public DateTime EndDate
      {
         get => mailItem.End;
         set => mailItem.End = value;
      }

      public string Location
      {
         get => mailItem.Location;
         set => mailItem.Location = value;
      }

      public void AddAttachment(string attachment) => mailItem.Attachments.Add(attachment);

      public void ResolveAll() => mailItem.Recipients.ResolveAll();

      public void AddSignature()
      {
         var _ = mailItem.GetInspector;
      }

      public void Display() => mailItem.Display(false);
   }
}