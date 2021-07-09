using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Collections;
using Core.Enumerables;
using Core.Matching;
using Core.Monads;
using Core.Strings;

namespace ReleasePalette
{
   public class Comparer
   {
      protected ListBox listBox;
      protected Label labelMessage;
      protected Pattern pattern;
      protected StringSet set;

      public Comparer(ListBox listBox, Label labelMessage, Pattern pattern)
      {
         this.listBox = listBox;
         this.labelMessage = labelMessage;
         this.pattern = pattern;

         set = new StringSet(true);
      }

      public ListBox ListBox => listBox;

      public StringSet Set => set;

      public void ShowSize()
      {
         var count = listBox.Items.Count;
         labelMessage.Text = count == 1 ? "1 item" : $"{count} items";
      }

      public void PasteIntoListBox(string source)
      {
         set.Clear();
         listBox.Items.Clear();

         foreach (var line in source.Lines())
         {
            if (line.Matches(pattern).If(out var result))
            {
               set.Add(result.FirstGroup);
            }
         }

         AddRange(set);
      }

      protected static IOrderedEnumerable<string> enumerableFromListBox(ListBox sourceListBox)
      {
         var objectArray = new object[sourceListBox.Items.Count];
         sourceListBox.Items.CopyTo(objectArray, 0);
         var enumerable = objectArray.Select(obj => obj.ToString()).OrderBy(i => i.ToInt());

         return enumerable;
      }

      protected IOrderedEnumerable<string> enumerableFromListBox() => enumerableFromListBox(listBox);

      public void CopyFromListBox()
      {
         var text = enumerableFromListBox().ToString(", ");
         Clipboard.SetText(text);
         labelMessage.Text = "Copied to clipboard";
      }

      public static void GetSetFromListBox(StringSet stringSet, ListBox sourceListBox)
      {
         stringSet.Clear();
         var enumerable = enumerableFromListBox(sourceListBox);
         stringSet.AddRange(enumerable);
      }

      public void GetSetFromListBox(StringSet stringSet) => GetSetFromListBox(stringSet, listBox);

      public void AddRange(IEnumerable<string> enumerable)
      {
         try
         {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            listBox.Items.AddRange(enumerable.OrderBy(i => i.ToInt()).Cast<object>().ToArray());
         }
         finally
         {
            listBox.EndUpdate();
            ShowSize();
         }
      }

      public void Compare(Comparer otherComparer)
      {
         var standardSet = new StringSet(true);
         GetSetFromListBox(standardSet);

         var otherSet = new StringSet(true);
         otherComparer.GetSetFromListBox(otherSet);

         var resultSet = new StringSet(true);
         resultSet.AddRange(standardSet.Where(item => !otherSet.Contains(item)));
         otherComparer.AddRange(resultSet);
      }

      public void Revert() => AddRange(set);

      public void PasteItemAndRemove()
      {
         if (listBox.SelectedItem.NotNull(out var itemObject))
         {
            var workItem = (string)itemObject;
            Clipboard.SetText(workItem);
            listBox.Items.Remove(itemObject);
            ShowSize();
         }
      }
   }
}