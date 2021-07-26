using Core.Monads;
using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public abstract class Content
   {
      public abstract Matched<Content> Matched();

      public abstract void Render(DocumentCore documentCore, Section section);
   }
}