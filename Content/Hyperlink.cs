using Core.Markup.Rtf;
using Core.Monads;

namespace ReleasePalette.Content
{
   public class Hyperlink : DocumentParagraph
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

      public override void Generate(State state, Paragraph paragraph)
      {
         base.Generate(state, paragraph);

         var format = paragraph.CharFormat(0, Text.Length - 1);
         format.LocalHyperlinkTip = Text;
         format.LocalHyperlink = link;
         format.ForegroundColor = state.Document.Color(0, 0, 255);
      }
   }
}