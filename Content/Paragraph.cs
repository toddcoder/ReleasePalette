using Core.Collections;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using Elistia.DotNetRtfWriter;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Paragraph : Generator
   {
      public static Paragraph FromText(string line, State state)
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
            return new Paragraph(line, _styleAndLength.Map(t => t.style));
         }
      }

      public static Paragraph Empty => new(string.Empty, none<Style>());

      public Paragraph(string text, Maybe<Style> _style)
      {
         Text = text;
         Style = _style;
      }

      public string Text { get; }

      public Maybe<Style> Style { get; }

      public override void Generate(State state)
      {
         var paragraph = state.Document.addParagraph();
         Style.IfThen(style => style.ApplyTo(state, paragraph));
         paragraph.setText(Text);

         state.ParagraphStash = paragraph.Some();
      }

      public override void Generate(State state, RtfParagraph paragraph)
      {
         Style.IfThen(style => style.ApplyTo(state, paragraph));
         paragraph.setText(Text);
      }
   }
}