using System.Collections.Generic;
using Core.Collections;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using SautinSoft.Document;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class MailContent
   {
      protected enum Stage
      {
         Style,
         Paragraph,
         Table
      }

      protected Source source;
      protected DocumentCore documentCore;
      protected Section section;
      protected StringHash<Formatting> styles;
      protected List<Content> contents;

      public MailContent(string source)
      {
         this.source = new Source(source);

         documentCore = new DocumentCore();
         section = new Section(documentCore);
         documentCore.Sections.Add(section);

         styles = new StringHash<Formatting>(true);
         contents = new List<Content>();
      }

      protected Result<Unit> parseStyles()
      {
         while (source.NextLineMatch(@"^([\w-]+)\s*([-=])>").If(out var result, out var line))
         {
            var (styleName, type) = result;
            var specification = line.Drop(result.Length);
            var isCharacter = type == "-";
            if (Formatting.FromSpecification(styleName, specification, isCharacter).ValueOrCast(out var formatting, out Result<Unit> asUnit))
            {
               styles[styleName] = formatting;
            }
            else
            {
               return asUnit;
            }
         }

         return Unit.Success();
      }

      protected Maybe<ParagraphFormatting> getParagraphFormatting(string styleName)
      {
         return
            from format in styles.Map(styleName)
            from paragraphFormat in format.IfCast<ParagraphFormatting>()
            select paragraphFormat;
      }

      protected Maybe<CharacterFormatting> getCharacterFormatting(string styleName)
      {
         return
            from format in styles.Map(styleName)
            from characterFormat in format.IfCast<CharacterFormatting>()
            select characterFormat;
      }

      protected Matched<Content> parseContent()
      {
         var result = parseParagraph();
         if (!result.IsNotMatched)
         {
            return result;
         }

         return parseTable();
      }

      protected Matched<Content> parseParagraph()
      {
         var items = new Items();
         if (source.NextLineMatch(@"^>\s*(?:\[([\w-]+)\]\s*)?").If(out var result, out var line))
         {
            var styleName = result.FirstGroup;
            line = line.Drop(result.Length).TrimLeft();
            items.ParagraphFormat = getParagraphFormatting(styleName);
         }

         foreach (var item in getItems(line))
         {
            items.Add(item);
         }

         return items.Match<Content>();
      }

      protected IEnumerable<Item> getItems(string line)
      {
         if (line.Matches(@"^([^\[]*)").If(out var result))
         {
            var text = result.FirstGroup;
            if (text.IsNotEmpty())
            {
               yield return new Item(text);

               line = line.Drop(text.Length);
            }
         }

         foreach (var match in line.AllMatches(@"\[([\w-]+)\]([^\]]*)"))
         {
            var styleName = match.FirstGroup;
            var text = match.SecondGroup;
            var item = new Item(text) { CharacterFormatting = getCharacterFormatting(styleName) };
            yield return item;
         }
      }

      protected Matched<Content> parseTable()
      {
         var grid = new Grid();

         return grid.Match<Content>();
      }

      public Result<string> Parse()
      {
         if (parseStyles().IfNot(out var exception))
         {
            return failure<string>(exception);
         }

         while (source.More)
         {
            if (parseContent().If(out var content, out var _exception))
            {
               contents.Add(content);
            }
            else if (_exception.If(out exception))
            {
               return failure<string>(exception);
            }
            else
            {
               break;
            }
         }

         /*foreach (var (styleName, formatting) in styles)
         {
            if (formatting.Format().ValueOrCast(out var format, out Result<string> asString))
            {
               documentCore.Styles.Add();
            }
         }*/

         foreach (var content in contents)
         {
            content.Render(documentCore, section);
         }

         return documentCore.ToString().Success();
      }
   }
}