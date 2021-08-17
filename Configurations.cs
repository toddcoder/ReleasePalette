using Core.Configurations;
using Core.Monads;

namespace ReleasePalette
{
   public class Configurations
   {
      public static Result<Configurations> Load()
      {
         return
            from configuration in ReleasePaletteConfiguration.Load()
            from mapConfigurationSource in configuration.MapFile.TryTo.Text
            from mapConfiguration in Core.Configurations.Configuration.FromString(mapConfigurationSource)
            let personalFile = configuration.MapFile.Folder + "personal.configuration"
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