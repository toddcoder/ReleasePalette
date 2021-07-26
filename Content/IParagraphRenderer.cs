using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public interface IParagraphRenderer
   {
      void Render(DocumentCore documentCore, Section section, Paragraph paragraph);
   }
}