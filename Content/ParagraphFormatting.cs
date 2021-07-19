using Core.Collections;
using Core.Monads;
using Core.Matching;
using Core.Strings;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class ParagraphFormatting
   {
      protected static Result<ParagraphFormatting> fromSpecification(string styleName, string specification)
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
               return $"Didn't understand specifier '{name}'".Failure<ParagraphFormatting>();
            }
         }

         var alignment = data.Map("alignment").CastAs<Alignment>().DefaultTo(() => Alignment.Left);
         var spaceBefore = data.Map("space-before").CastAs<double>().DefaultTo(() => 1.0);
         var spaceAfter = data.Map("space-after").CastAs<double>().DefaultTo(() => 1.0);

         return new ParagraphFormatting(styleName, alignment, spaceBefore, spaceAfter).Success();
      }

      public ParagraphFormatting(string styleName, Alignment alignment, double spaceBefore, double spaceAfter)
      {
         StyleName = styleName;
         Alignment = alignment;
         SpaceBefore = spaceBefore;
         SpaceAfter = spaceAfter;
      }

      public string StyleName { get; }

      public Alignment Alignment { get; }

      public double SpaceBefore { get; }

      public double SpaceAfter { get; }
   }
}