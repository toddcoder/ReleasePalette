using System.Collections.Generic;

namespace ReleasePalette.Content
{
   public class GridCell
   {
      protected List<Items> content;

      public GridCell()
      {
         content = new List<Items>();
      }

      public void Add(Items items) => content.Add(items);
   }
}