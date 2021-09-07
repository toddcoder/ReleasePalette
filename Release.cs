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

      public FolderName ReleaseFolder { get; set; }

      public string ReleaseValidPattern { get; set; }

      public string ReleaseValue { get; set; }

      protected bool isValid(string release) => release.IsMatch(ReleaseValidPattern);

      public bool IsNew { get; set; }

      protected void Release_Load(object sender, EventArgs e)
      {
         IsNew = false;

         if (ReleaseValue.IsNotEmpty() && isValid(ReleaseValue))
         {
            textRelease.Text = ReleaseValue;
         }

         listReleases.Items.AddRange(ReleaseFolder.Files
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
         if (DialogResult == DialogResult.OK)
         {
            if (isValid(textRelease.Text))
            {
               ReleaseValue = textRelease.Text;
            }

            IsNew = !(ReleaseFolder + $"{ReleaseValue}.configuration").Exists();
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

      protected void buttonOk_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
         Close();
      }

      protected void buttonCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }
   }
}