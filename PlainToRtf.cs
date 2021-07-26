using System.Collections.Generic;
using System.Linq;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using static Core.Monads.AttemptFunctions;
using SautinSoft.Document;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class PlainToRtf
   {
      protected string documentSource;
      protected Source source;
      protected DocumentCore documentCore;
      protected Section section;

      public PlainToRtf(string documentSource)
      {
         this.documentSource = documentSource;
         source = new Source(documentSource);

         documentCore = new DocumentCore();
         section = new Section(documentCore);
         documentCore.Sections.Add(section);
      }

      public Result<string> Convert() => tryTo(convert);

      protected Result<string> convert()
      {
         while (source.NextLine().If(out var line))
         {
            if (line.StartsWith(":"))
            {
               paragraph(line);
            }
            else if (line.StartsWith("|"))
            {

            }
            else
            {
               var paragraph = new Paragraph(documentCore, line);
               section.Blocks.Add(paragraph);
            }
         }

         return documentCore.ToString().Success();
      }

      protected static Maybe<CharacterFormat> getCharacterFormat(string specifiers)
      {
         var characterFormat = new CharacterFormat();
         var modified = false;
         foreach (var specifier in specifiers.Split(@"\s*;\s*"))
         {
            var (name, value) = specifier.Split2(@"\s*=\s*");
            switch (name)
            {
               case "font-name":
                  characterFormat.FontName = value;
                  modified = true;
                  break;
               case "font-size":
                  characterFormat.Size = value.ToDouble();
                  modified = true;
                  break;
               case "bold":
                  characterFormat.Bold = value.Same("true");
                  modified = true;
                  break;
               case "italic":
                  characterFormat.Italic = value.Same("true");
                  modified = true;
                  break;
            }
         }

         return maybe(modified, () => characterFormat);
      }

      protected void paragraph(string line)
      {
         var lines = new List<string>();

         if (line.Matches("^:(.*)$").If(out var result))
         {
            var _characterFormat = getCharacterFormat(result.FirstGroup);
            while (source.More)
            {
               if (!source.Current.IsMatch(@"^[:\|]") && source.NextLine().If(out line))
               {
                  lines.Add(line);
               }
               else
               {
                  break;
               }
            }

            var paragraph = new Paragraph(documentCore);
            foreach (var run in lines.Select(runLine => new Run(documentCore, $"{runLine}\n")))
            {
               _characterFormat.IfThen(c => run.CharacterFormat = c);
               paragraph.Inlines.Add(run);
            }
         }
      }

      protected (string, Maybe<int>) getWidth(string specifiers)
      {
         if (specifiers.Matches(@"\bwidth:\s*(\d+)").If(out var result))
         {
            var width = result.FirstGroup.ToInt();
            var remaining = result.FirstMatch = string.Empty;
            remaining = remaining.Substitute(@";\s*;", ";");
            return (remaining, width.Some());
         }
         else
         {
            return (specifiers, none<int>());
         }
      }

      protected void table(string line)
      {
         var lines = new List<string>();

         if (line.Matches(@"^(\|)+(.*)$").If(out var result))
         {
            var columnCount = result.FirstGroup.Length;
            var (specifiers, _width) = getWidth(result.SecondGroup);
            var _characterFormat = getCharacterFormat(specifiers);

            while (source.More)
            {
               if (!source.Current.IsMatch(@"^[:\|]") && source.NextLine().If(out line))
               {
                  lines.Add(line);
               }
               else
               {
                  break;
               }
            }


         }
      }
   }
}