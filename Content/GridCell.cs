using System.Collections;
using System.Collections.Generic;

namespace ReleasePalette.Content
{
   public class GridCell : IEnumerable<Items>
   {
      protected List<Items> content;

      public GridCell()
      {
         content = new List<Items>();
      }

      public void Add(Items items) => content.Add(items);

      public IEnumerator<Items> GetEnumerator() => content.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}