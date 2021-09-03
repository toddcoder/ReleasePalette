using System;
using System.Linq;
using Core.Applications;
using Core.Computers;
using Core.Monads;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public class SelfSetup
   {
      protected static string[] requiredFileNames;

      static SelfSetup()
      {
         requiredFileNames = new[] { "releasePalette", "map", "personal" };
      }

      protected FolderName userFolder;

      public SelfSetup(FolderName userFolder)
      {
         this.userFolder = userFolder;
      }

      public Result<Unit> SetUp()
      {
         try
         {
            if (!userFolder.Exists())
            {
               userFolder.CreateIfNonExistent();
            }

            var resources = new Resources<SelfSetup>("Setup");

            foreach (var file in requiredFileNames.Select(rfn => userFolder + $"{rfn}.configuration").Where(f => !f.Exists()))
            {
               var source = resources.String(file.NameExtension);
               file.Text = source;
            }

            return unit;
         }
         catch (Exception exception)
         {
            return exception;
         }
      }
   }
}