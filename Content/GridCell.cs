using System.Collections.Generic;
using SautinSoft.Document;
using SautinSoft.Document.Tables;

namespace ReleasePalette.Content
{
   public class GridCell : ITableRowRenderer
   {
      protected List<Items> content;

      public GridCell()
      {
         content = new List<Items>();
      }

      public void Add(Items items) => content.Add(items);

      public void Render(DocumentCore documentCore, Section section, TableRow row)
      {
         foreach (var items in content)
         {
            items.Render(documentCore, section);
         }
      }
   }
}