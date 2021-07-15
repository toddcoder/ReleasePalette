using System;

namespace ReleasePalette
{
   public interface IOutlookItem
   {
      public string To { get; set; }

      public string Cc { get; set; }

      public string Subject { get; set; }

      public string Body { get; set; }

      public DateTime StartDate { get; set; }

      public DateTime EndDate { get; set; }

      public string Location { get; set; }

      public void AddAttachment(string attachment);

      public void ResolveAll();

      public void AddSignature();

      public void Display();
   }
}