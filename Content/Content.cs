using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public abstract class Content
   {
      public abstract void Render(DocumentCore documentCore, Section section);
   }
}