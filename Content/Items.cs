using System.Collections;
using System.Collections.Generic;

namespace ReleasePalette.Content
{
   public class Items : IEnumerable<Item>
   {
      protected List<Item> items;

      public Items()
      {
         items = new List<Item>();
      }

      public void Add(Item item) => items.Add(item);

      public IEnumerator<Item> GetEnumerator() => items.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}