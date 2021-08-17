using System;
using Core.Applications;
using Core.Computers;
using Core.Monads;

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

            foreach (var requiredFileName in requiredFileNames)
            {
               var fileName = $"{requiredFileName}.configuration";
               var file = userFolder + fileName;
               if (!file.Exists())
               {
                  var source = resources.String(fileName);
                  file.Text = source;
               }
            }

            return Unit.Value;
         }
         catch (Exception exception)
         {
            return exception;
         }
      }
   }
}