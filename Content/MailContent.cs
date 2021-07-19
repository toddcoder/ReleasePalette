using Core.Collections;
using Core.Matching;
using SautinSoft.Document;

namespace ReleasePalette.Content
{
   public class MailContent
   {
      protected Source source;
      protected DocumentCore documentCore;
      protected Section section;
      protected StringHash<Formatting> styles;

      public MailContent(string source)
      {
         this.source = new Source(source);

         documentCore = new DocumentCore();
         section = new Section(documentCore);
         documentCore.Sections.Add(section);

         styles = new StringHash<Formatting>(true);
      }
   }
}