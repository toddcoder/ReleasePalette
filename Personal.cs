namespace ReleasePalette
{
   public class Personal
   {
      public Personal()
      {
         OtherTo = string.Empty;
         Signature = string.Empty;
         Location = string.Empty;
      }

      public string OtherTo { get; set; }

      public string Signature { get; set; }

      public string Location { get; set; }
   }
}