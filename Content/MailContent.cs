using System.Collections.Generic;
using System.Linq;
using Core.Collections;
using Core.Enumerables;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using Elistia.DotNetRtfWriter;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class MailContent
   {
      protected const string PATTERN_STYLE_DEFINITION = @"^([\w-]+)\s*:\s*";
      protected const string PATTERN_TABLE_WIDTHS = @"^&table\(([^\)]+)\)";
      protected const string PATTERN_SPLIT_ON_COMMA = @"\s*,\s*";
      protected const string PATTERN_TABLE_ROW = @"^\|";
      protected const string PATTERN_LINE_BREAK = "^>!";
      protected const string PATTERN_STYLED_PARAGRAPH = @"^>\s*\[([\w-]+)\]\s*";
      protected const string PATTERN_PARAGRAPH = "^>";

      protected State state;

      public MailContent()
      {
         var document = new RtfDocument(PaperSize.Letter, PaperOrientation.Portrait, Lcid.English);
         state = new State(document);
      }

      public Result<RtfDocument> Parse(string text)
      {
         var source = new Source(text);
         var tableLines = new List<string>();
         var paragraphLines = new List<string>();
         var _style = none<Style>();
         var generators = new List<Generator>();
         var widths = new List<float>();

         void generateTable()
         {
            if (tableLines.Count > 0)
            {
               var table = new Table(state, tableLines, widths);
               generators.Add(table);
               tableLines.Clear();
               widths.Clear();
            }
         }

         void generateParagraph()
         {
            if (paragraphLines.Count > 0)
            {
               var paragraphText = paragraphLines.ToString(" ");
               var paragraph = new Paragraph(paragraphText, _style);
               generators.Add(paragraph);
               paragraphLines.Clear();
               _style = none<Style>();
            }
         }

         while (source.NextLine().If(out var line))
         {
            if (line.Matches(PATTERN_STYLE_DEFINITION).If(out var result))
            {
               var styleName = result.FirstGroup;
               var specification = line.Drop(result.Length).Trim();
               if (Style.FromSpecification(specification, true).ValueOrCast(out var style, out Result<RtfDocument> asDocument))
               {
                  state.Styles[styleName] = style;
               }
               else
               {
                  return asDocument;
               }
            }
            else if (line.Matches(PATTERN_TABLE_WIDTHS).If(out result))
            {
               generateParagraph();
               generateTable();

               widths.AddRange(result.FirstGroup.Split(PATTERN_SPLIT_ON_COMMA).Select(s => s.ToFloat(1)));
            }
            else if (line.Matches(PATTERN_TABLE_ROW).If(out result))
            {
               generateParagraph();

               tableLines.Add(line.Drop(result.Length).Trim());
            }
            else if (line.IsMatch(PATTERN_LINE_BREAK))
            {
               generateParagraph();
               generateTable();

               generators.Add(Paragraph.Empty);
            }
            else if (line.Matches(PATTERN_STYLED_PARAGRAPH).If(out result))
            {
               generateParagraph();
               generateTable();

               var styleName = result.FirstGroup;
               _style = state.Styles.Map(styleName);
               paragraphLines.Add(line.Drop(result.Length).Trim());
            }
            else if (line.Matches(PATTERN_PARAGRAPH).If(out result))
            {
               generateParagraph();
               generateTable();

               paragraphLines.Add(line.Drop(result.Length).Trim());
            }
            else
            {
               paragraphLines.Add(line);
            }
         }

         generateParagraph();
         generateTable();

         foreach (var generator in generators)
         {
            generator.Generate(state);
         }

         return state.Document.Success();
      }
   }
}