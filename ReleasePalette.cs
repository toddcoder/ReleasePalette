using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Collections;
using Core.Configurations;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using Core.WinForms;
using Core.WinForms.Documents;

namespace ReleasePalette
{
   public partial class ReleasePalette : Form
   {
      protected ReleasePaletteConfiguration configuration;
      protected FreeMenus menus;
      protected StringHash<Item> items;
      protected StringHash<ItemType> itemTypes;
      protected StringHash<int> keyToIndexes;
      protected StringHash labelToKeys;

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
         menus.Menu("Commands", "Paste From Clipboard", (_, _) => pasteFromClipboard(), "^%V");
         menus.Menu("Commands", "Copy To Clipboard", (_, _) => copyToClipboard(), "^%C");

         menus.Menu("Releases");
         menus.Menu("Releases", "Set Release", (_, _) => setRelease(), "^R");
         menus.RenderMainMenu();

         loadItems().OnSuccess(_ => loadListView()).OnFailure(exception => showException(exception));
      }

      protected void pasteFromClipboard()
      {
         if (Clipboard.ContainsText())
         {
            var text = Clipboard.GetText();

            if (text.IsNotEmpty())
            {
               textValue.Text = Clipboard.GetText();
               apply();
               showSuccess($"Clipboard pasted to {labelName.Text}");
            }
            else
            {
               showFailure("Clipboard has no text");
            }
         }
         else
         {
            showFailure("Clipboard has no text");
         }
      }

      protected void copyToClipboard()
      {
         var text = textValue.Text;
         if (text.IsNotEmpty())
         {
            Clipboard.SetText(text);
            showSuccess($"Copied text from {labelName.Text} to clipboard");
         }
         else
         {
            showFailure("Clipboard has no text");
         }
      }

      protected void saveData()
      {
         try
         {
            var dataHash = new StringHash(true);
            foreach (ListViewItem item in listViewItems.Items)
            {
               var label = item.SubItems[0].Text;
               var value = item.SubItems[1].Text;
               if (labelToKeys.If(label, out var key))
               {
                  dataHash[key] = value;
               }
            }

            if (dataHash.ToConfiguration().If(out var dataConfiguration, out var exception))
            {
               configuration.DataFile.Text = dataConfiguration.ToString();
               showSuccess("Data saved");
            }
            else
            {
               showException(exception);
            }
         }
         catch (Exception exception)
         {
            showException(exception);
         }
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

      protected void showFailure(string message)
      {
         labelMessage.ForeColor = Color.Black;
         labelMessage.BackColor = Color.Yellow;
         labelMessage.Text = message;
      }

      protected ReleasePalette showSuccess(string message)
      {
         labelMessage.ForeColor = Color.White;
         labelMessage.BackColor = Color.Green;
         labelMessage.Text = message;

         return this;
      }

      protected void showTitle()
      {
         Text = $"Release Palette - Release {configuration.Release}";
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

      protected Result<Unit> loadItems()
      {
         var _configuration =
            from source in configuration.MapFile.TryTo.Text
            from configurationFromString in Configuration.FromString(source)
            select configurationFromString;
         if (_configuration.ValueOrCast(out var mapConfiguration, out Result<Unit> asUnit))
         {
            items = new StringHash<Item>(true);
            itemTypes = new StringHash<ItemType>(true);
            keyToIndexes = new StringHash<int>(true);
            var index = 0;
            labelToKeys = new StringHash(true);
            foreach (var (key, group) in mapConfiguration.Groups())
            {
               var _result =
                  from groupLabel in @group.GetValue("label")
                  from type in @group.GetValue("type")
                  from groupType in type.AsEnumeration<ItemType>()
                  select (groupLabel, groupType);
               if (_result.If(out var label, out var itemType))
               {
                  items[key] = new Item(label, itemType);
                  itemTypes[label] = itemType;
                  keyToIndexes[key] = index++;
                  labelToKeys[label] = key;
               }
            }

            if (configuration.DataFile.Exists())
            {
               var _data =
                  from source in configuration.DataFile.TryTo.Text
                  from configurationFromString in Configuration.FromString(source)
                  select configurationFromString;
               if (_data.ValueOrCast(out var dataConfiguration, out asUnit))
               {
                  foreach (var (key, value) in dataConfiguration.Values())
                  {
                     if (keyToIndexes.If(key, out index))
                     {
                        listViewItems.Items[index].SubItems[1].Text = value;
                     }
                  }
               }
            }

            return Unit.Success();
         }
         else
         {
            return asUnit;
         }
      }

      protected void loadListView()
      {
         try
         {
            listViewItems.BeginUpdate();
            listViewItems.Items.Clear();
            foreach (var (_, item) in items)
            {
               var listViewItem = new ListViewItem(item.Label);
               listViewItem.SubItems.Add(string.Empty);
               listViewItems.Items.Add(listViewItem);
            }

            if (items.Count > 0)
            {
               listViewItems.Items[0].Selected = true;
               listViewItems.Select();
            }
         }
         finally
         {
            listViewItems.EndUpdate();
            listViewItems.AutoSizeColumns();
         }
      }

      protected void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (listViewItems.SelectedItems.Count > 0)
            {
               var listViewItem = listViewItems.SelectedItems[0];
               var key = listViewItem.Text;
               labelName.Text = key;
               var value = listViewItem.SubItems[1].Text;
               textValue.Text = value;

               if (itemTypes.If(key, out var itemType) && itemType == ItemType.Url && value.IsNotEmpty())
               {
                  showMessage($"Opening {value.Truncate(40)}");
                  webBrowser.Navigate(value);
               }
            }
         }
         catch (Exception exception)
         {
            Console.WriteLine(exception);
            throw;
         }
      }

      protected void buttonPasteFromClipboard_Click(object sender, EventArgs e) => pasteFromClipboard();

      protected void buttonPasteToClipboard_Click(object sender, EventArgs e) => copyToClipboard();

      protected void apply()
      {
         if (listViewItems.SelectedItems.Count > 0)
         {
            listViewItems.SelectedItems[0].SubItems[1].Text = textValue.Text;
         }
      }

      protected void buttonApply_Click(object sender, EventArgs e) => apply();

      protected void textValue_DragOver(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(typeof(string)))
         {
            e.Effect = DragDropEffects.Copy;
         }
         else
         {
            e.Effect = DragDropEffects.None;
         }
      }

      protected void textValue_DragDrop(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(typeof(string)))
         {
            textValue.Text = (string)e.Data.GetData(typeof(string));
         }
      }

      protected void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
         if (e.Url.AbsoluteUri.Contains("about:blank"))
         {
            return;
         }

         var url = e.Url.AbsoluteUri;
         showSuccess($"Navigated to {url.Truncate(40)}");
      }

      protected void ReleasePalette_FormClosing(object sender, FormClosingEventArgs e) => saveData();
   }
}