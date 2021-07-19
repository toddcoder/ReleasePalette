using Core.Assertions;
using Core.Collections;
using Core.Monads;
using Core.Matching;
using Core.Objects;
using Core.Strings;
using SautinSoft.Document;
using static Core.Monads.AttemptFunctions;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Formatting
   {
      protected static Result<Formatting> fromSpecification(string styleName, string specification)
      {
         var data = new StringHash<object>(true);
         foreach (var specifier in specification.Split(@"\s*;\s*"))
         {
            var (name, value) = specifier.Split2(@"\s*=\s*");
            var _object = name switch
            {
               "font-name" => value.Some<object>(),
               "font-size" => value.AsInt().CastAs<object>(),
               "bold" or "italic" => value.Same("true").Some<object>(),
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

         return
            from fontNameAssert in data.Must().HaveKeyOf("font-name").OrFailure()
            from fontSizeAssert in data.Must().HaveKeyOf("font-size").OrFailure()
            from fontName in data.TryTo["font-name"].CastAs<string>()
            from fontSize in data.TryTo["font-size"].CastAs<double>()
            from bold in data.Map("bold").DefaultTo(() => false).CastAs<bool>()
            from italic in data.Map("italic").DefaultTo(() => false).CastAs<bool>()
            select new Formatting(styleName, fontName, fontSize, bold, italic);
      }

      public static Result<Formatting> FromSpecification(string styleName, string specification) => tryTo(() => fromSpecification(styleName, specification));

      public Formatting(string styleName, string fontName, double size, bool bold = false, bool italic = false)
      {
         StyleName = styleName;
         FontName = fontName;
         Size = size;
         Bold = bold;
         Italic = italic;
      }

      public string StyleName { get; }

      public string FontName { get; }

      public double Size { get; }

      public bool Bold { get; }

      public bool Italic { get; }

      protected CharacterFormat characterFormat()
      {
         return new() { Style = new CharacterStyle(StyleName), FontName = FontName, Size = Size, Bold = Bold, Italic = Italic };
      }

      public Result<CharacterFormat> CharacterFormat() => tryTo(characterFormat);
   }
}