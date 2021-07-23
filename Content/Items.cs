using System.Collections;
using System.Collections.Generic;
using Core.Matching;
using Core.Monads;
using SautinSoft.Document;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Items : Content, IEnumerable<Item>
   {
      protected const string PATTERN_HYPERLINK = @"^([^@]+)@(https?://.*)$";
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
         Inline addStringRun(string text, Maybe<CharacterFormatting> _characterFormatting)
         {
            if (text.Matches(PATTERN_HYPERLINK).If(out var result))
            {
               var displayText = result.FirstGroup;
               var address = result.SecondGroup;
               var hyperlink = new Hyperlink(documentCore, address, displayText);
               return hyperlink;
            }
            else
            {
               var run = new Run(documentCore, text);
               if (_characterFormatting.If(out var characterFormatting))
               {
                  var styleName = characterFormatting.StyleName;
                  if (documentCore.Styles.Contains(styleName))
                  {
                     run.CharacterFormat.Style = (CharacterStyle)documentCore.Styles[styleName];
                  }
               }

               return run;
            }
         }

         Maybe<SpecialCharacter> addSpecialCharacter(char character)
         {
            SpecialCharacterType specialCharacter;
            switch (character)
            {
               case '\t':
                  specialCharacter = SpecialCharacterType.Tab;
                  break;
               case '\r' or '\n':
                  specialCharacter = SpecialCharacterType.LineBreak;
                  break;
               default:
                  return none<SpecialCharacter>();
            }

            return new SpecialCharacter(documentCore, specialCharacter).Some();
         }

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
            foreach (var eitherStringOrChar in item)
            {
               switch (eitherStringOrChar)
               {
                  case Left<string, char> left:
                     var run = addStringRun(left.Value, item.CharacterFormatting);
                     paragraph.Inlines.Add(run);
                     break;
                  case Right<string, char> right:
                     if (addSpecialCharacter(right.Value).If(out var specialCharacter))
                     {
                        paragraph.Inlines.Add(specialCharacter);
                     }
                     break;
               }
            }
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