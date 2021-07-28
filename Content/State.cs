using Core.Collections;
using Core.Monads;
using Elistia.DotNetRtfWriter;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette.Content
{
   public class State
   {
      public State(RtfDocument document)
      {
         Document = document;
         Styles = new StringHash<Style>(true);
         Fonts = new AutoStringHash<FontDescriptor>(true, fontName => Document.createFont(fontName), true);
         ParagraphStash = none<RtfParagraph>();
      }

      public RtfDocument Document { get; }

      public StringHash<Style> Styles { get; }

      // ReSharper disable once CollectionNeverUpdated.Global
      public AutoStringHash<FontDescriptor> Fonts { get; }

      public Maybe<RtfParagraph> ParagraphStash { get; set; }
   }
}