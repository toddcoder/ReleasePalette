using Core.Collections;
using Core.Monads;
using static Core.Monads.MonadFunctions;
using Core.Markup.Rtf;

namespace ReleasePalette.Content
{
   public class State
   {
      public State(Document document)
      {
         Document = document;
         Styles = new StringHash<Style>(true);
         Fonts = new AutoStringHash<FontDescriptor>(true, fontName => Document.Font(fontName), true);
         ParagraphStash = nil;
      }

      public Document Document { get; }

      public StringHash<Style> Styles { get; }

      // ReSharper disable once CollectionNeverUpdated.Global
      public AutoStringHash<FontDescriptor> Fonts { get; }

      public Maybe<Paragraph> ParagraphStash { get; set; }
   }
}