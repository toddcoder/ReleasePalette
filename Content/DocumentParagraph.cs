using Core.Collections;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class DocumentParagraph : Generator
   {
      public static DocumentParagraph FromText(string line, State state)
      {
         var _styleAndLength =
            from result in line.Matches(@"^\[([\w-]+)\]")
            from foundStyle in state.Styles.Map(result.FirstGroup)
            select (style: foundStyle, length: result.Length);
         _styleAndLength.IfThen(t => line = line.Drop(t.length));

         if (line.Matches(@"^([^@]+)(?<!/)@(https?://.+)").If(out var linkResult))
         {
            return new Hyperlink(linkResult.FirstGroup, linkResult.SecondGroup, _styleAndLength.Map(t => t.style));
         }
         else
         {
            return new DocumentParagraph(line, _styleAndLength.Map(t => t.style));
         }
      }

      public static DocumentParagraph Empty => new(string.Empty, nil);

      public DocumentParagraph(string text, Maybe<Style> _style)
      {
         Text = text;
         Style = _style;
      }

      public string Text { get; }

      public Maybe<Style> Style { get; }

      public override void Generate(State state)
      {
         var paragraph = state.Document.Paragraph();
         Style.IfThen(style => style.ApplyTo(state, paragraph));
         paragraph.Text = Text;

         state.ParagraphStash = paragraph;
      }

      public override void Generate(State state, Core.Markup.Rtf.Paragraph paragraph)
      {
         Style.IfThen(style => style.ApplyTo(state, paragraph));
         paragraph.Text = Text;
      }
   }
}