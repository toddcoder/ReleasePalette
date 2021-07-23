using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core.Monads;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class Item : IEnumerable<Either<string, char>>
   {
      public Item(string text)
      {
         Text = text;
         CharacterFormatting = none<CharacterFormatting>();
      }

      public string Text { get; }

      public Maybe<CharacterFormatting> CharacterFormatting { set; get; }

      public IEnumerator<Either<string, char>> GetEnumerator()
      {
         var builder = new StringBuilder();
         foreach (var ch in Text)
         {
            if (ch < 32)
            {
               if (builder.Length > 0)
               {
                  yield return builder.ToString().Left<string, char>();

                  builder.Clear();
               }

               yield return ch.Right<string, char>();
            }
            else
            {
               builder.Append(ch);
            }
         }
         if (builder.Length > 0)
         {
            yield return builder.ToString().Left<string, char>();
         }
      }

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}