using Core.Monads;
using RtfWriter;

namespace ReleasePalette.Content
{
   public class Hyperlink : Paragraph
   {
      protected string link;

      public Hyperlink(string text, string link, Maybe<Style> _style) : base(text, _style)
      {
         this.link = link;
      }

      public override void Generate(State state)
      {
         base.Generate(state);

         if (state.ParagraphStash.If(out var paragraph))
         {
            Generate(state, paragraph);
         }
      }

      public override void Generate(State state, RtfParagraph paragraph)
      {
         base.Generate(state, paragraph);

         var format = paragraph.CharFormat(0, Text.Length - 1);
         format.LocalHyperlinkTip = Text.Some();
         format.LocalHyperlink = link.Some();
         format.ForegroundColor = state.Document.Color(new RtfColor(0, 0, 255)).Some();
      }
   }
}