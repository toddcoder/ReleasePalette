using Core.Monads;
using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public interface IFormatting
   {
      Result<Either<CharacterFormat, ParagraphFormat>> RenderFormat();
   }
}