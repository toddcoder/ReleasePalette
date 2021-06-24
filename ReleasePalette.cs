using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Matching;
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
         Pattern.IsFriendly = false;
      }

      protected void ReleasePalette_Load(object sender, EventArgs e)
      {
         ReleasePaletteConfiguration.Load()
            .OnSuccess(newConfiguration => setConfiguration(newConfiguration).showSuccess("Configuration loaded").showTitle())
            .OnFailure(exception => showException(exception));

         menus = new FreeMenus { Form = this.Some<Form>() };

         menus.Menu("Commands");
         menus.Menu("Commands", "Paste From Clipboard", (_, _) => MessageBox.Show(this, "Paste From Clipboard", "Test"), "^%V");
         menus.Menu("Commands", "Copy To Clipboard", (_, _) => MessageBox.Show(this, "Copy To Clipboard", "Test"), "^%C");

         menus.Menu("Releases");
         menus.Menu("Releases", "Set Release", (_, _) => setRelease(), "^R");
         menus.RenderMainMenu();
      }

      protected void showMessage(string message)
      {
         labelMessage.ForeColor = SystemColors.ControlText;
         labelMessage.BackColor = SystemColors.Control;
         labelMessage.Text = message;
      }

      protected ReleasePalette showException(Exception exception)
      {
         labelMessage.ForeColor = Color.White;
         labelMessage.BackColor = Color.Red;
         labelMessage.Text = exception.Message;

         return this;
      }

      protected ReleasePalette showSuccess(string message)
      {
         labelMessage.ForeColor = Color.White;
         labelMessage.BackColor = Color.Green;
         labelMessage.Text = message;

         return this;
      }

      protected ReleasePalette showTitle()
      {
         Text = $"Release Palette - Release {configuration.Release}";
         return this;
      }

      protected ReleasePalette setConfiguration(ReleasePaletteConfiguration newConfiguration)
      {
         configuration = newConfiguration;
         return this;
      }

      protected void setRelease()
      {
         using var releaseDialog = new Release { ReleaseValue = configuration.Release, ReleaseValidPattern = configuration.ReleaseValidPattern };
         if (releaseDialog.ShowDialog(this) == DialogResult.OK)
         {
            configuration.Release = releaseDialog.ReleaseValue;
            configuration.Save()
               .OnSuccess(_ => showSuccess("Configuration saved").showTitle())
               .OnFailure(exception => showException(exception));
         }
      }
   }
}