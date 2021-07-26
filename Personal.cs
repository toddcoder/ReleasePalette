using Core.Collections;

namespace ReleasePalette
{
   public class Personal
   {
      public Personal()
      {
         OtherTo = string.Empty;
         Signature = string.Empty;
         ZoomUrl = string.Empty;
         ZoomMeetingId = string.Empty;
         ZoomPassword = string.Empty;
         ZoomPhone = string.Empty;
      }

      public string OtherTo { get; set; }

      public string Signature { get; set; }

      public string ZoomUrl { get; set; }

      public string ZoomMeetingId { get; set; }

      public string ZoomPassword { get; set; }

      public string ZoomPhone { get; set; }

      public void SetReplacements(AutoStringHash replacements)
      {
         replacements["other-to"] = OtherTo;
         replacements["signature"] = Signature;
         replacements["zoom.url"] = ZoomUrl;
         replacements["zoom.meetingId"] = ZoomMeetingId;
         replacements["zoom.password"] = ZoomPassword;
         replacements["zoom.phone"] = ZoomPhone;
      }
   }
}