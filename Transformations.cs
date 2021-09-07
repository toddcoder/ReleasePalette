using Core.Matching;
using Core.Monads;
using static Core.Monads.AttemptFunctions;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class Transformations
   {
      protected string source;

      public Transformations(string source)
      {
         this.source = source;
      }

      public Result<string> Transform(string[] functions)
      {
         foreach (var function in functions)
         {
            var result = function switch
            {
               "fileToUri" => fileToUri(),
               _ => fail($"Didn't recognize function {function}")
            };
            if (result.IfNot(out var exception))
            {
               return exception;
            }
         }

         return source;
      }

      protected Result<Unit> fileToUri() => tryTo(() =>
      {
         source = source.Substitute("^file://", @"\\");
         source = source.Substitute("/", @"\");

         return unit;
      });
   }
}