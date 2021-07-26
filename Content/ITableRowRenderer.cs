using SautinSoft.Document;
using SautinSoft.Document.Tables;

namespace ReleasePalette.Content
{
   public interface ITableRowRenderer
   {
      void Render(DocumentCore documentCore, Section section, TableRow row);
   }
}