using System;
using Core.Monads;

namespace ReleasePalette
{
   public class Appointment : Email
   {
      protected Result<DateTime> _startDate;
      protected DateTime startDate;
      protected Result<DateTime> _endDate;
      protected DateTime endDate;
      protected Result<string> _location;
      protected string location;

      public Appointment()
      {
         _startDate = "Start date is required".Failure<DateTime>();
         _endDate = "End date is required".Failure<DateTime>();
         _location = "Location is required".Failure<string>();
      }

      public DateTime StartDate
      {
         get => _startDate.ForceValue();
         set => _startDate = value.Success();
      }

      public DateTime EndDate
      {
         get => _endDate.ForceValue();
         set => _endDate = value.Success();
      }

      public string Location
      {
         get => _location.ForceValue();
         set => _location = value.Success();
      }

      public override IOutlookItem GetOutlookItem() => new OutlookAppointmentItem();

      protected override void checkArguments()
      {
         base.checkArguments();

         startDate = _startDate.ForceValue();
         endDate = _endDate.ForceValue();
         location = _location.ForceValue();
      }

      protected override void setArguments(IOutlookItem mailItem)
      {
         base.setArguments(mailItem);

         mailItem.StartDate = startDate;
         mailItem.EndDate = endDate;
         mailItem.Location = location;
      }
   }
}