
using Core.Markup.Rtf;

namespace ReleasePalette.Content
{
   public abstract class Generator
   {
      public abstract void Generate(State state);

      public abstract void Generate(State state, Paragraph paragraph);
   }
}