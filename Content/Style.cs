using Core.Matching;
using Core.Monads;
using Core.Strings;
using Elistia.DotNetRtfWriter;

namespace ReleasePalette.Content
{
   public class Style
   {
      public static Result<Style> FromSpecification(string specification, bool isParagraph)
      {
         var style = new Style { IsParagraph = isParagraph };

         foreach (var specifier in specification.Split(@"\s*;\s*"))
         {
            var (name, value) = specifier.Split2(@"\s*=\s*");
            switch (name)
            {
               case "font-name":
                  style.FontName = value;
                  break;
               case "font-size":
                  if (value.Single().ValueOrCast(out var fontSize, out Result<Style> asStyle))
                  {
                     style.FontSize = fontSize;
                  }
                  else
                  {
                     return asStyle;
                  }

                  break;
               case "bold":
                  style.Bold = value.Same("true");
                  break;
               case "italic":
                  style.Italic = value.Same("true");
                  break;
               case "alignment":
                  if (value.Enumeration<Alignment>().ValueOrCast(out var alignment, out asStyle))
                  {
                     style.Alignment = alignment;
                  }
                  else
                  {
                     return asStyle;
                  }

                  break;
               default:
                  return $"Didn't understand specifier '{specifier}'".Failure<Style>();
            }
         }

         return style.Success();
      }

      public Style()
      {
         IsParagraph = true;
         FontName = "Calibri";
         FontSize = 11;
         Bold = false;
         Italic = false;
         Alignment = Alignment.Left;
      }

      public bool IsParagraph { get; set; }

      public string FontName { get; set; }

      public float FontSize { get; set; }

      public bool Bold { get; set; }

      public bool Italic { get; set; }

      public Alignment Alignment { get; set; }

      public void ApplyTo(State state, RtfParagraph paragraph)
      {
         paragraph.DefaultCharFormat.Font = state.Fonts[FontName];
         paragraph.DefaultCharFormat.FontSize = FontSize;
         if (Bold)
         {
            paragraph.DefaultCharFormat.FontStyle.addStyle(FontStyleFlag.Bold);
         }

         if (Italic)
         {
            paragraph.DefaultCharFormat.FontStyle.addStyle(FontStyleFlag.Italic);
         }
      }
   }
}