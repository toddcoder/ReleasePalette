using System.Collections;
using System.Collections.Generic;

namespace ReleasePalette.Content
{
   public class GridLine : IEnumerable<GridCell>
   {
      protected List<GridCell> gridCells;

      public GridLine()
      {
         gridCells = new List<GridCell>();
      }

      public int CellCount => gridCells.Count;

      public void Add(GridCell gridCell) => gridCells.Add(gridCell);

      public IEnumerator<GridCell> GetEnumerator() => gridCells.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   }
}