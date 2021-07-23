using System.Collections.Generic;
using System.Linq;
using Core.Monads;
using SautinSoft.Document;
using SautinSoft.Document.Tables;
using static Core.Monads.MonadFunctions;

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

      public override Matched<Content> Matched() => gridLines.Count > 0 ? this.Match<Content>() : noMatch<Content>();

      public override void Render(DocumentCore documentCore, Section section)
      {
         var table = new Table(documentCore) { TableFormat = { DefaultCellPadding = new Padding(0.05, 0.01, 0.05, 0.01, LengthUnit.Inch) } };
         section.Blocks.Add(table);

         var maxCellCount = gridLines.Max(gl => gl.CellCount);

         foreach (var gridLine in gridLines)
         {
            var tableRow = new TableRow(documentCore);

            foreach (var gridCell in gridLine)
            {
               var tableCell = new TableCell(documentCore);

               foreach (var items in gridCell)
               {
                  var paragraph = items.GetParagraph(documentCore);
                  tableCell.Blocks.Add(paragraph);
               }

               tableRow.Cells.Add(tableCell);
            }

            if (tableRow.Cells.Count < maxCellCount)
            {
               foreach (var _ in Enumerable.Range(0, maxCellCount - tableRow.Cells.Count))
               {
                  var tableCell = new TableCell(documentCore);
                  var paragraph = new Paragraph(documentCore);
                  var run = new Run(documentCore, string.Empty);
                  paragraph.Inlines.Add(run);
                  tableCell.Blocks.Add(paragraph);
                  tableRow.Cells.Add(tableCell);
               }
            }

            table.Rows.Add(tableRow);
         }
      }
   }
}