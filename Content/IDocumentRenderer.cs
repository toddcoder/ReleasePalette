using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public interface IDocumentRenderer
   {
      void Render(DocumentCore documentCore, Section section);
   }
}