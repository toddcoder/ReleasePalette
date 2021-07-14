using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.Computers;
using Core.Matching;
using Core.Strings;

namespace ReleasePalette
{
   public partial class Release : Form
   {
      public Release()
      {
         InitializeComponent();
      }

      public FolderName DataFolder { get; set; }

      public string ReleaseValidPattern { get; set; }

      public string ReleaseValue { get; set; }

      protected bool isValid(string release) => release.IsMatch(ReleaseValidPattern);

      protected void Release_Load(object sender, EventArgs e)
      {
         if (ReleaseValue.IsNotEmpty() && isValid(ReleaseValue))
         {
            textRelease.Text = ReleaseValue;
         }

         listReleases.Items.AddRange(DataFolder.Files
            .Where(f => isValid(f.Name))
            .OrderBy(f => f.Name)
            .Select(f => f.Name)
            .Cast<object>().ToArray());
      }

      protected void textRelease_TextChanged(object sender, EventArgs e)
      {
         if (isValid(textRelease.Text))
         {
            showValid();
         }
         else
         {
            showInvalid();
         }
      }

      protected void showValid()
      {
         labelState.BackColor = Color.Green;
         labelState.Text = "Valid";
         buttonOk.Enabled = true;
      }

      protected void showInvalid()
      {
         labelState.BackColor = Color.Red;
         labelState.Text = "Invalid";
         buttonOk.Enabled = false;
      }

      protected void Release_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (isValid(textRelease.Text))
         {
            ReleaseValue = textRelease.Text;
         }
      }

      protected void listReleases_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (listReleases.SelectedIndex > -1)
         {
            var release = (string)listReleases.SelectedItem;
            textRelease.Text = release;
         }
      }

      protected void listReleases_DoubleClick(object sender, EventArgs e)
      {
         if (listReleases.SelectedIndex > -1)
         {
            var release = (string)listReleases.SelectedItem;
            if (isValid(release))
            {
               ReleaseValue = release;
               Close();
            }
         }
      }
   }
}