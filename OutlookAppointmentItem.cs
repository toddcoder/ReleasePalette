using System;
using Microsoft.Office.Interop.Outlook;
using Core.Matching;

namespace ReleasePalette
{
   public class OutlookAppointmentItem : IOutlookItem
   {
      protected AppointmentItem mailItem;

      public OutlookAppointmentItem(OutlookArguments arguments)
      {
         var application = new Application();
         mailItem = (AppointmentItem)application.CreateItem(OlItemType.olAppointmentItem);
         mailItem.ReminderSet = true;
         mailItem.ReminderMinutesBeforeStart = 15;
         mailItem.BusyStatus = OlBusyStatus.olBusy;
         mailItem.Start = DateTime.Today.AddHours(20);
         mailItem.End = mailItem.Start.AddHours(2);

         foreach (var recipient in arguments.To.Split(@"\s*;\s*"))
         {
            mailItem.Recipients.Add(recipient);
         }

         mailItem.Subject = arguments.Subject;
         mailItem.Body = arguments.Body;
         mailItem.Location = arguments.Location;
      }

      public void AddAttachment(string attachment) => mailItem.Attachments.Add(attachment);

      public void GenerateBody()
      {
      }

      public void ResolveAll() => mailItem.Recipients.ResolveAll();

      public void AddSignature()
      {
         var _ = mailItem.GetInspector;
      }

      public void Display() => mailItem.Display(false);
   }
}