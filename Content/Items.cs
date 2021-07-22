using System.Collections;
using System.Collections.Generic;
using Core.Monads;
using SautinSoft.Document;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Items : Content, IEnumerable<Item>
   {
      protected List<Item> items;

      public Items()
      {
         items = new List<Item>();
         ParagraphFormat = none<ParagraphFormatting>();
      }

      public override Matched<Content> Matched() => items.Count > 0 ? this.Match<Content>() : noMatch<Content>();

      public void Add(Item item) => items.Add(item);

      public Maybe<ParagraphFormatting> ParagraphFormat { get; set; }

      public Paragraph GetParagraph(DocumentCore documentCore)
      {
         var paragraph = new Paragraph(documentCore);

         if (ParagraphFormat.If(out var paragraphFormatting))
         {
            var styleName = paragraphFormatting.StyleName;
            if (documentCore.Styles.Contains(styleName))
            {
               paragraph.ParagraphFormat.Style = (ParagraphStyle)documentCore.Styles[styleName];
            }
         }

         foreach (var item in items)
         {
            var run = new Run(documentCore, item.Text);
            if (item.CharacterFormatting.If(out var characterFormatting))
            {
               var styleName = characterFormatting.StyleName;
               if (documentCore.Styles.Contains(styleName))
               {
                  run.CharacterFormat.Style = (CharacterStyle)documentCore.Styles[styleName];
               }
            }

            paragraph.Inlines.Add(run);
         }

         return paragraph;
      }

      public override void Render(DocumentCore documentCore, Section section)
      {
         var paragraph = GetParagraph(documentCore);
         section.Blocks.Add(paragraph);
      }

      public IEnumerator<Item> GetEnumerator() => items.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}