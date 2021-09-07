using System;
using System.IO;
using System.Text;
using Core.Computers;
using Core.Configurations;
using Core.Monads;

namespace ReleasePalette
{
   public class ConfigurationFileWatcher
   {
      protected FileName file;
      protected FileSystemWatcher watcher;

      public event EventHandler FileChanged;

      public ConfigurationFileWatcher(ReleasePaletteConfiguration configuration)
      {
         var fileName = $"{configuration.Release}.configuration";
         file = configuration.ReleaseFolder + fileName;
         watcher = new FileSystemWatcher(configuration.ReleaseFolder.FullPath, fileName)
         {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
            EnableRaisingEvents = true,
            IncludeSubdirectories = false
         };
         watcher.Changed += (_, _) => FileChanged?.Invoke(this, EventArgs.Empty);
      }

      public FileName File
      {
         get => file;
         set
         {
            file = value;
            watcher.Path = file.Folder.FullPath;
            watcher.Filter = file.NameExtension;
         }
      }

      public void ResetFile(ReleasePaletteConfiguration configuration)
      {
         var fileName = $"{configuration.Release}.configuration";
         File = configuration.ReleaseFolder + fileName;
      }

      public void ResetFile(ReleasePaletteConfiguration configuration, Configuration dataConfiguration)
      {
         var fileName = $"{configuration.Release}.configuration";
         var dataFile = configuration.ReleaseFolder + fileName;
         dataFile.Text = dataConfiguration.ToString();
         dataFile.TryTo.SetText(dataConfiguration.ToString(), Encoding.UTF8);

         File = dataFile;
      }

      public Result<Configuration> DataConfiguration()
      {
         return
            from source in file.TryTo.Text
            from configuration in Configuration.FromString(source)
            select configuration;
      }
   }
}