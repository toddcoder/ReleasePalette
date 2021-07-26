using Core.Collections;
using Core.Exceptions;
using Core.Monads;
using Core.Matching;
using Core.Strings;
using SautinSoft.Document;
using static Core.Monads.AttemptFunctions;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class ParagraphFormatting : Formatting
   {
      protected static Result<Formatting> fromSpecification(string styleName, string specification)
      {
         var data = new StringHash<object>(true);
         foreach (var specifier in specification.Split(@"\s*;\s*"))
         {
            var (name, value) = specifier.Split2(@"\s*=\s*");
            var _object = name switch
            {
               "alignment" => value.AsEnumeration<Alignment>().CastAs<object>(),
               "space-before" or "space-after" => value.AsDouble().CastAs<object>(),
               _ => none<object>()
            };
            if (_object.If(out var obj))
            {
               data[name] = obj;
            }
            else
            {
               return $"Didn't understand specifier '{name}'".Failure<Formatting>();
            }
         }

         var alignment = data.Map("alignment").CastAs<Alignment>().DefaultTo(() => Alignment.Left);
         var spaceBefore = data.Map("space-before").CastAs<double>().DefaultTo(() => 1.0);
         var spaceAfter = data.Map("space-after").CastAs<double>().DefaultTo(() => 1.0);

         return new ParagraphFormatting(styleName, alignment, spaceBefore, spaceAfter).Success<Formatting>();
      }

      public static Result<Formatting> FromSpecification(string styleName, string specification)
      {
         return tryTo(() => fromSpecification(styleName, specification));
      }

      public ParagraphFormatting(string styleName, Alignment alignment, double spaceBefore, double spaceAfter) : base(styleName)
      {
         Alignment = alignment;
         SpaceBefore = spaceBefore;
         SpaceAfter = spaceAfter;
      }

      public Alignment Alignment { get; }

      public double SpaceBefore { get; }

      public double SpaceAfter { get; }

      public override bool IsCharacter => false;

      public override bool IsParagraph => true;

      protected HorizontalAlignment getHorizontalAlignment() => Alignment switch
      {
         Alignment.Left => HorizontalAlignment.Left,
         Alignment.Right => HorizontalAlignment.Right,
         Alignment.Center => HorizontalAlignment.Center,
         Alignment.Justify => HorizontalAlignment.Justify,
         _ => throw $"Didn't understand alignment {Alignment}".Throws()
      };

      protected ParagraphStyle paragraphFormat()
      {
         return new(StyleName)
         {
            ParagraphFormat = new ParagraphFormat { Alignment = getHorizontalAlignment(), SpaceBefore = SpaceBefore, SpaceAfter = SpaceAfter }
         };
      }

      public override Result<Style> Style() => tryTo(paragraphFormat).CastAs<Style>();
   }
}