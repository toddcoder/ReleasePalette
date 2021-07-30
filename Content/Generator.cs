using RtfWriter;

namespace ReleasePalette.Content
{
   public abstract class Generator
   {
      public abstract void Generate(State state);

      public abstract void Generate(State state, RtfParagraph paragraph);
   }
}