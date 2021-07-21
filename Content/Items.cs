using System.Collections.Generic;
using Core.Monads;
using SautinSoft.Document;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Items : Content
   {
      protected List<Item> items;

      public Items()
      {
         items = new List<Item>();
         ParagraphFormat = none<ParagraphFormatting>();
      }

      public void Add(Item item) => items.Add(item);

      public Maybe<ParagraphFormatting> ParagraphFormat { get; set; }

      public override void Render(DocumentCore documentCore, Section section)
      {
      }
   }
}