using Core.Computers;
using Core.Configurations;
using Core.Monads;

namespace ReleasePalette
{
   public class Configurations
   {
      public static Result<Configurations> Load(FolderName userFolder)
      {
         return
            from configuration in ReleasePaletteConfiguration.Load()
            let mapFile = configuration.ReleaseFolder + "map.configuration"
            from mapConfigurationSource in mapFile.TryTo.Text
            from mapConfiguration in Core.Configurations.Configuration.FromString(mapConfigurationSource)
            let personalFile = userFolder + "personal.configuration"
            from personalSource in personalFile.TryTo.Text
            from personalConfiguration in Core.Configurations.Configuration.FromString(personalSource)
            from personal in personalConfiguration.Deserialize<Personal>()
            select new Configurations(configuration, mapConfiguration, personal);
      }

      public Configurations(ReleasePaletteConfiguration configuration, Configuration mapConfiguration, Personal personal)
      {
         Configuration = configuration;
         MapConfiguration = mapConfiguration;
         Personal = personal;
      }

      public ReleasePaletteConfiguration Configuration { get; }

      public Configuration MapConfiguration { get; }

      public Personal Personal { get; }

      public void Deconstruct(out ReleasePaletteConfiguration configuration, out Configuration mapConfiguration, out Personal personal)
      {
         configuration = Configuration;
         mapConfiguration = MapConfiguration;
         personal = Personal;
      }
   }
}