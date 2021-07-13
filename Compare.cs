using System;
using System.Windows.Forms;

namespace ReleasePalette
{
   public partial class Compare : Form
   {
      protected Comparer leftComparer;
      protected Comparer rightComparer;

      public Compare()
      {
         InitializeComponent();

         leftComparer = new Comparer(listLeft, labelLeftMessage, @"/edit/(\d+)");
         rightComparer = new Comparer(listRight, labelRightMessage, @">(\d+)");
      }

      protected void buttonPasteLeft_Click(object sender, EventArgs e)
      {
         if (Clipboard.ContainsText())
         {
            var text = Clipboard.GetText();
            leftComparer.PasteIntoListBox(text);
         }
      }

      protected void buttonPasteRight_Click(object sender, EventArgs e)
      {
         if (Clipboard.ContainsText())
         {
            var text = Clipboard.GetText();
            rightComparer.PasteIntoListBox(text);
         }
      }

      protected void buttonCopyLeft_Click(object sender, EventArgs e) => leftComparer.CopyFromListBox();

      protected void buttonCopyRight_Click(object sender, EventArgs e) => rightComparer.CopyFromListBox();

      protected void buttonCompareLeft_Click(object sender, EventArgs e) => leftComparer.Compare(rightComparer);

      protected void buttonCompareRight_Click(object sender, EventArgs e) => rightComparer.Compare(leftComparer);

      protected void buttonRevertLeft_Click(object sender, EventArgs e) => leftComparer.Revert();

      protected void buttonRevertRight_Click(object sender, EventArgs e) => rightComparer.Revert();

      protected void listLeft_SelectedIndexChanged(object sender, EventArgs e) => leftComparer.PasteItemAndRemove();

      protected void listRight_SelectedIndexChanged(object sender, EventArgs e) => rightComparer.PasteItemAndRemove();
   }
}