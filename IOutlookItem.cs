namespace ReleasePalette
{
   public interface IOutlookItem
   {
      public void AddAttachment(string attachment);

      public void GenerateBody();

      public void ResolveAll();

      public void AddSignature();

      public void Display();
   }
}