namespace ReleasePalette.Content
{
   public class Item
   {
      public Item(string text, Formatting formatting)
      {
         Text = text;
         Formatting = formatting;
      }

      public string Text { get; }

      public Formatting Formatting { get; }
   }
}