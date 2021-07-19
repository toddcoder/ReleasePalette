using Core.Matching;
using Core.Monads;
using Core.Strings;
using static Core.Monads.AttemptFunctions;
using SautinSoft.Document;

namespace ReleasePalette
{
   public class PlainToRtf
   {
      protected string documentSource;
      protected Source source;
      protected DocumentCore documentCore;

      public PlainToRtf(string documentSource)
      {
         this.documentSource = documentSource;
         source = new Source(documentSource);

         documentCore = new DocumentCore();
         var section = new Section(documentCore);
         documentCore.Sections.Add(section);
      }

      public Result<string> Convert() => tryTo(convert);

      protected Result<string> convert()
      {
         while (source.More)
         {
            var line = source.Current
         }
         return documentCore.ToString().Success();
      }

      protected void paragraph()
      {

      }
   }
}