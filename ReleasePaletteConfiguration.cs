using System.Text;
using Core.Computers;
using Core.Configurations;
using Core.Monads;

namespace ReleasePalette
{
   public class ReleasePaletteConfiguration
   {
      protected static FolderName configurationFolder;
      protected static FileName configurationFile;

      static ReleasePaletteConfiguration()
      {
         configurationFolder = @"~\AppData\Local\ReleasePalette";
         configurationFile = configurationFolder + "releasePalette.configuration";
      }

      public static Result<ReleasePaletteConfiguration> Load()
      {
         if (configurationFile.Exists())
         {
            return
               from source in configurationFile.TryTo.Text
               from configuration in Configuration.FromString(source)
               from releasePaletteConfiguration in configuration.Deserialize<ReleasePaletteConfiguration>()
               select releasePaletteConfiguration;
         }
         else
         {
            var configuration = new ReleasePaletteConfiguration
            {
               Release = "r-6.24.0",
               ReleaseFolder = @"\\pdfsevolv01corp\data\ProductionSupport\ReleasePalette",
               ReleaseValidPattern = @"^r-\d{1,2}\.\d{1,2}\.\d{1,2}$",
               MapFile = "map.configuration",
            };

            return configuration.Save().Map(_ => configuration);
         }
      }

      public string Release { get; set; }

      public FolderName ReleaseFolder { get; set; }

      public string ReleaseValidPattern { get; set; }

      public string MapFile { get; set; }

      public Result<Unit> Save()
      {
         return
            from configuration in Configuration.Serialize(this, "merge-palette")
            from saved in configurationFile.TryTo.SetText(configuration.ToString(), Encoding.UTF8)
            select saved;
      }
   }
}