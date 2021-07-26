using Core.Monads;
using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public abstract class Formatting
   {
      public static Result<Formatting> FromSpecification(string styleName, string specification, bool isCharacter)
      {
         if (isCharacter)
         {
            return CharacterFormatting.FromSpecification(styleName, specification);
         }
         else
         {
            return ParagraphFormatting.FromSpecification(styleName, specification);
         }
      }

      protected Formatting(string styleName)
      {
         StyleName = styleName;
      }

      public string StyleName { get; }

      public abstract bool IsCharacter { get; }

      public abstract bool IsParagraph { get; }

      public abstract Result<Style> Style();
   }
}