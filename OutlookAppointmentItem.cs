using System;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using Core.Matching;
using ReleasePalette.Content;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace ReleasePalette
{
   public class OutlookAppointmentItem : IOutlookItem
   {
      protected AppointmentItem mailItem;
      protected string body;

      public OutlookAppointmentItem(OutlookArguments arguments)
      {
         var application = new Application();
         mailItem = (AppointmentItem)application.CreateItem(OlItemType.olAppointmentItem);
         mailItem.ReminderSet = true;
         mailItem.ReminderMinutesBeforeStart = 15;
         mailItem.BusyStatus = OlBusyStatus.olBusy;
         mailItem.Start = DateTime.Today.AddHours(20);
         mailItem.End = mailItem.Start.AddHours(2);
         mailItem.MeetingStatus = OlMeetingStatus.olMeeting;

         foreach (var recipient in arguments.To.Split(@"\s*;\s*"))
         {
            mailItem.Recipients.Add(recipient);
         }

         mailItem.Subject = arguments.Subject;
         body = arguments.Body;
         mailItem.Location = arguments.Personal.ZoomUrl;
      }

      public void AddAttachment(string attachment) => mailItem.Attachments.Add(attachment);

      public void GenerateBody()
      {
         var mailContent = new MailContent();
         if (mailContent.Parse(body).If(out var document))
         {
            var rtfBody = document.Render();
            var array = Encoding.ASCII.GetBytes(rtfBody);
            mailItem.RTFBody = array;
         }
      }

      public void ResolveAll() => mailItem.Recipients.ResolveAll();

      public void AddSignature()
      {
      }

      public void Display() => mailItem.Display(false);
   }
}