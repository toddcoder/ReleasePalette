using Core.Configurations;
using Core.Monads;

namespace ReleasePalette
{
   public class AppointmentGenerator : EmailGenerator
   {
      public AppointmentGenerator(string source, Personal personal) : base(source, personal)
      {
      }

      protected override Result<OutlookArguments> getArguments(Configuration configuration)
      {
         return
            from to in configuration.GetValue("to").Result("'To' is required")
            from subject in configuration.GetValue("subject").Result("'Subject' is required")
            from body in configuration.GetValue("body").Result("'Body' is required")
            from location in configuration.GetValue("location").Result("'Location' is required")
            select new OutlookArguments(to, personal.OtherTo, string.Empty, subject, body, location);
      }

      protected override IOutlookItem getOutlookItem(OutlookArguments arguments) => new OutlookAppointmentItem(arguments);
   }
}