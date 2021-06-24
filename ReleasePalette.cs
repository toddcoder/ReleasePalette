using System;
using System.Windows.Forms;
using Core.Monads;
using Core.WinForms.Documents;

namespace ReleasePalette
{
   public partial class ReleasePalette : Form
   {
      protected ReleasePaletteConfiguration configuration;
      protected FreeMenus menus;

      public ReleasePalette()
      {
         InitializeComponent();
      }

      protected void ReleasePalette_Load(object sender, EventArgs e)
      {
         configuration = ReleasePaletteConfiguration.Load().ForceValue();

         menus = new FreeMenus { Form = this.Some<Form>() };

         menus.Menu("Commands");
         menus.Menu("Commands", "Paste From Clipboard", (_, _) => MessageBox.Show(this, "Paste From Clipboard", "Test"),"^%V");
         menus.Menu("Commands", "Copy To Clipboard", (_, _) => MessageBox.Show(this, "Copy To Clipboard", "Test"), "^%C");

         menus.Menu("Releases");
         menus.Menu("Releases","Set Release");
         menus.RenderMainMenu();
      }

      protected void setRelease()
      {

      }
   }
}