﻿using System;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using Core.Matching;
using ReleasePalette.Content;

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

         foreach (var recipient in arguments.To.Split(@"\s*;\s*"))
         {
            mailItem.Recipients.Add(recipient);
         }

         mailItem.Subject = arguments.Subject;
         body = arguments.Body;
         mailItem.Location = arguments.Personal.ZoomUrl;
      }

      public void AddAttachment(string attachment) => mailItem.Attachments.Add(attachment);

      protected static string joinRtf(string rtf1, string rtf2)
      {
         var builder = new StringBuilder(@"{\rtf1\ansi");
         builder.Append(rtf1);
         builder.Append(rtf2);
         builder.Append("}");

         return builder.ToString();
      }

      public void GenerateBody()
      {
         var mailContent = new MailContent(body);
         if (mailContent.Parse().If(out var newBody))
         {
            var rtfBody = Encoding.ASCII.GetBytes(newBody);
            mailItem.RTFBody = rtfBody;
         }
      }

      public void ResolveAll() => mailItem.Recipients.ResolveAll();

      public void AddSignature()
      {
      }

      public void Display() => mailItem.Display(false);
   }
}