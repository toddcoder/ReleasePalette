using System;
using System.Windows.Forms;

namespace ReleasePalette
{
   internal static class Program
   {
      [STAThread]
      internal static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new ReleasePalette());
      }
   }
}