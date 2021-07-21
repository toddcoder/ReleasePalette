using Core.Monads;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Item
   {
      public Item(string text)
      {
         Text = text;
         CharacterFormatting = none<CharacterFormatting>();
      }

      public string Text { get; }

      public Maybe<CharacterFormatting> CharacterFormatting { set; get; }
   }
}