using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public class LineFeed : IParagraphRenderer
   {
      public void Render(DocumentCore documentCore, Section section, Paragraph paragraph)
      {
         var lineBreak = new SpecialCharacter(documentCore, SpecialCharacterType.LineBreak);
         paragraph.Inlines.Add(lineBreak);
      }
   }
}