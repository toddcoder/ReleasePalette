using System;
using System.Drawing;
using System.Windows.Forms;
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

      public string ReleaseValidPattern { get; set; }

      public string ReleaseValue { get; set; }

      protected bool isValid(string release) => release.IsMatch(ReleaseValidPattern);

      protected void Release_Load(object sender, EventArgs e)
      {
         if (ReleaseValue.IsNotEmpty())
         {
         }
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
   }
}