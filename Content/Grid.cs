using System.Collections.Generic;
using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public class Grid : Content
   {
      protected List<GridLine> gridLines;

      public Grid()
      {
         gridLines = new List<GridLine>();
      }

      public void Add(GridLine gridLine) => gridLines.Add(gridLine);

      public override void Render(DocumentCore documentCore, Section section)
      {
      }
   }
}