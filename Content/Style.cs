using Core.Markup.Rtf;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using static Core.Monads.MonadFunctions;

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
                  if (value.Single().If(out var fontSize, out var exception))
                  {
                     style.FontSize = fontSize;
                  }
                  else
                  {
                     return exception;
                  }

                  break;
               case "bold":
                  style.Bold = value.Same("true");
                  break;
               case "italic":
                  style.Italic = value.Same("true");
                  break;
               case "alignment":
                  if (value.Enumeration<Alignment>().If(out var alignment, out exception))
                  {
                     style.Alignment = alignment;
                  }
                  else
                  {
                     return exception;
                  }

                  break;
               default:
                  return fail($"Didn't understand specifier '{specifier}'");
            }
         }

         return style;
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

      public void ApplyTo(State state, Paragraph paragraph)
      {
         paragraph.DefaultCharFormat.Font = state.Fonts[FontName];
         paragraph.DefaultCharFormat.FontSize = FontSize;
         if (Bold)
         {
            paragraph.DefaultCharFormat.FontStyle += FontStyleFlag.Bold;
         }

         if (Italic)
         {
            paragraph.DefaultCharFormat.FontStyle += FontStyleFlag.Italic;
         }
      }
   }
}