﻿using System.Collections.Generic;
using System.Linq;
using Core.Matching;
using Elistia.DotNetRtfWriter;

namespace ReleasePalette.Content
{
   public class Table : Generator
   {
      public class Row
      {
         protected Paragraph[] paragraphs;

         public Row(Paragraph[] paragraphs)
         {
            this.paragraphs = paragraphs;
         }

         public Paragraph this[int index] => paragraphs[index];
      }

      protected Row[] rows;
      protected int columnCount;
      protected float[] widths;

      public Table(State state, List<string> tableLines, List<float> widths)
      {
         var data = tableLines.Select(line => line.Split(@"\|")).ToArray();
         this.widths = widths.ToArray();
         var rowCount = data.Length;
         columnCount = data.Max(a => a.Length);

         rows = new Row[rowCount];
         for (var row = 0; row < rowCount; row++)
         {
            var paragraphs = new Paragraph[columnCount];
            var dataRow = data[row];
            for (var column = 0; column < dataRow.Length; column++)
            {
               paragraphs[column] = Paragraph.FromText(dataRow[column], state);
            }

            for (var column = dataRow.Length; column < columnCount; column++)
            {
               paragraphs[column] = Paragraph.Empty;
            }

            rows[row] = new Row(paragraphs);
         }
      }

      public override void Generate(State state)
      {
         var table = state.Document.addTable(rows.Length, columnCount, 11);
         table.Margins[Direction.Left] = 20;
         table.Margins[Direction.Right] = 20;

         for (var row = 0; row < rows.Length; row++)
         {
            var currentRow = rows[row];
            for (var column = 0; column < columnCount; column++)
            {
               if (column < widths.Length)
               {
                  table.setColWidth(column, widths[column] * 72);
               }

               var paragraph = table.cell(row, column).addParagraph();
               var currentParagraph = currentRow[column];
               currentParagraph.Generate(state, paragraph);
            }
         }
      }

      public override void Generate(State state, RtfParagraph paragraph)
      {
      }
   }
}