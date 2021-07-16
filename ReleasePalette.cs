﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Applications;
using Core.Collections;
using Core.Computers;
using Core.Configurations;
using Core.Enumerables;
using Core.Matching;
using Core.Monads;
using Core.Strings;
using Core.WinForms;
using Core.WinForms.Documents;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public partial class ReleasePalette : Form
   {
      protected ReleasePaletteConfiguration configuration;
      protected Configuration mapConfiguration;
      protected Personal personal;
      protected FreeMenus menus;
      protected StringHash<ItemType> itemTypes;
      protected StringHash<int> keyToIndexes;
      protected StringHash labelToKeys;
      protected StringHash<StringSet> keyToList;

      public ReleasePalette()
      {
         InitializeComponent();
         Pattern.IsFriendly = false;
      }

      protected void ReleasePalette_Load(object sender, EventArgs e)
      {
         var _configurations =
            from _configuration in ReleasePaletteConfiguration.Load()
            from mapConfigurationSource in _configuration.MapFile.TryTo.Text
            from _mapConfiguration in Configuration.FromString(mapConfigurationSource)
            from personalSource in (_configuration.MapFile.Folder + "personal.configuration").TryTo.Text
            from personalConfiguration in Configuration.FromString(personalSource)
            from _personal in personalConfiguration.Deserialize<Personal>()
            select (_configuration, _mapConfiguration, _personal);
         if (_configurations.If(out configuration, out mapConfiguration, out personal, out var exception))
         {
            showSuccess("Configurations loaded");

            menus = new FreeMenus { Form = this.Some<Form>() };

            menus.Menu("Commands");
            menus.Menu("Commands", "Paste From Clipboard", (_, _) => pasteFromClipboard(), "^%V");
            menus.Menu("Commands", "Copy To Clipboard", (_, _) => copyToClipboard(), "^%C");
            menus.Menu("Commands", "Apply", (_, _) => apply(), "^A");
            menus.Menu("Commands", "Open", (_, _) => apply(), "^O");

            menus.Menu("Tools");
            menus.Menu("Tools", "Compare", (_, _) => showCompareDialog(), "^K");

            menus.Menu("Releases");
            menus.Menu("Releases", "Set Release", (_, _) => setRelease(), "^R");

            menus.Menu("Emails");
            menus.Menu("Emails", "Refresh DB", (_, _) => refreshDbEmail());
            menus.Menu("Emails", "Migrate DB", (_, _) => migrateDbEmail());
            menus.Menu("Emails", "Deploy Build to Environment", (_, _) => deployEnvironmentEmail());
            menus.Menu("Emails", "Release Notes", (_, _) => releaseNotesEmail());
            menus.Menu("Emails", "Request Security Review", (_, _) => requestSecurityReviewEmail());
            menus.Menu("Emails", "Request PSR Run", (_, _) => requestPsrRunEmail());
            menus.Menu("Emails", "Schedule Deployment", (_, _) => scheduleDeploymentEmail());
            menus.MenuSeparator("Emails");
            menus.Menu("Emails", "Post-Deployment Validation", (_, _) => postDeploymentValidationEmail());
            menus.Menu("Emails", "Post-Deployment Request for EstreamPS and Staging18ua", (_, _) => postDeploymentRequestEmail());
            menus.Menu("Emails", "Release Closed", (_, _) => closedEmail());
            menus.Menu("Emails", "Release -> Master -> Develop", (_, _) => ToDevelopEmail());

            menus.RenderMainMenu();

            loadItems().OnSuccess(_ => listViewItems.AutoSizeColumns()).OnFailure(loadException => showException(loadException));
         }
         else
         {
            showException(exception);
         }
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
               var dataFile = configuration.MapFile.Folder + $"{configuration.Release}.configuration";
               dataFile.Text = dataConfiguration.ToString();
               dataFile.TryTo.SetText(dataConfiguration.ToString(), Encoding.UTF8)
                  .OnSuccess(_ => showSuccess("Data saved"))
                  .OnFailure(e => showException(e));
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

      protected ReleasePalette setMapConfiguration(Configuration newConfiguration)
      {
         mapConfiguration = newConfiguration;
         return this;
      }

      protected void setRelease()
      {
         using var releaseDialog = new Release
         {
            ReleaseValue = configuration.Release, ReleaseValidPattern = configuration.ReleaseValidPattern, DataFolder = configuration.MapFile.Folder
         };
         if (releaseDialog.ShowDialog(this) == DialogResult.OK)
         {
            configuration.Release = releaseDialog.ReleaseValue;

            var dataFile = configuration.MapFile.Folder + $"{configuration.Release}.configuration";
            if (!dataFile.Exists())
            {
               saveData();
            }

            configuration.Save()
               .OnSuccess(_ =>
               {
                  loadItems();
                  showTitle();
               })
               .OnFailure(exception => showException(exception));
         }
      }

      protected Result<Unit> loadItems()
      {
         try
         {
            listViewItems.BeginUpdate();
            listViewItems.Items.Clear();

            itemTypes = new StringHash<ItemType>(true);
            keyToIndexes = new StringHash<int>(true);
            var index = 0;
            labelToKeys = new StringHash(true);
            keyToList = new StringHash<StringSet>(true);
            foreach (var (key, group) in mapConfiguration.Groups())
            {
               var _result =
                  from groupLabel in @group.GetValue("label")
                  from type in @group.GetValue("type")
                  from groupType in type.AsEnumeration<ItemType>()
                  select (groupLabel, groupType);
               if (_result.If(out var label, out var itemType))
               {
                  itemTypes[label] = itemType;
                  keyToIndexes[key] = index++;
                  labelToKeys[label] = key;
                  listViewItems.Items.Add(label);
                  if (itemType == ItemType.List && group.GetValue("values").If(out var valuesSource))
                  {
                     var valuesList = valuesSource.Split(@"\s*,\s*").Select(i => i.Trim()).ToArray();
                     if (valuesList.Length <= 1)
                     {
                        return "List types must have at least two items".Failure<Unit>();
                     }

                     keyToList[key] = new StringSet(true, valuesList);
                  }
               }
            }

            var dataFile = configuration.MapFile.Folder + $"{configuration.Release}.configuration";
            if (dataFile.Exists())
            {
               var _data =
                  from source in dataFile.TryTo.Text
                  from configurationFromString in Configuration.FromString(source)
                  select configurationFromString;
               if (_data.ValueOrCast(out var dataConfiguration, out Result<Unit> asUnit))
               {
                  foreach (var (key, value) in dataConfiguration.Values())
                  {
                     if (keyToIndexes.If(key, out index))
                     {
                        listViewItems.Items[index].SubItems.Add(value);
                     }
                  }
               }
               else
               {
                  return asUnit;
               }
            }

            listViewItems.Items[0].Selected = true;

            return Unit.Success();
         }
         catch (Exception exception)
         {
            return failure<Unit>(exception);
         }
         finally
         {
            listViewItems.EndUpdate();
         }
      }

      protected void listViewItems_SelectedIndexChanged(object sender, EventArgs e) => selectedIndexAction(none<string>());

      protected void selectedIndexAction(Maybe<string> _value)
      {
         try
         {
            if (listViewItems.SelectedItems.Count > 0)
            {
               var listViewItem = listViewItems.SelectedItems[0];
               var key = listViewItem.Text;
               labelName.Text = key;

               if (_value.If(out var value))
               {
                  listViewItem.SubItems[1].Text = value;
               }
               else
               {
                  value = listViewItem.SubItems[1].Text;
               }

               textValue.Text = value;

               if (itemTypes.If(key, out var itemType))
               {
                  if (itemType == ItemType.Url && value.IsNotEmpty())
                  {
                     showMessage($"Opening {value.Truncate(40)}");
                     webBrowser.Navigate(value);
                  }
                  else
                  {
                     webBrowser.Navigate("about:blank");
                  }
               }
            }
         }
         catch (Exception exception)
         {
            Console.WriteLine(exception);
         }
      }

      protected void buttonPasteFromClipboard_Click(object sender, EventArgs e) => pasteFromClipboard();

      protected void buttonPasteToClipboard_Click(object sender, EventArgs e) => copyToClipboard();

      protected void apply()
      {
         if (listViewItems.SelectedItems.Count > 0)
         {
            listViewItems.SelectedItems[0].SubItems[1].Text = textValue.Text;
            saveData();
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
            var value = (string)e.Data.GetData(typeof(string));
            selectedIndexAction(value.Some());
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

      protected void ReleasePalette_FormClosing(object sender, FormClosingEventArgs e)
      {
         saveData();
         configuration.Save();
      }

      protected void open()
      {
         if (listViewItems.SelectedItems.Count > 0)
         {
            var label = listViewItems.SelectedItems[0].SubItems[0].Text;
            var possibleUrl = listViewItems.SelectedItems[0].SubItems[1].Text;
            if (itemTypes.If(label, out var type))
            {
               if (type == ItemType.Url)
               {
                  Process.Start(possibleUrl);
               }
               else
               {
                  showFailure($"Item {label} isn't a URL");
               }
            }
            else
            {
               showFailure($"Couldn't find label {label}");
            }
         }
      }

      protected void buttonOpen_Click(object sender, EventArgs e) => open();

      protected void showCompareDialog()
      {
         using var compare = new Compare();
         compare.ShowDialog();
      }

      protected Maybe<(string label, string text)> getLineItem()
      {
         if (listViewItems.SelectedItems.Count > 0)
         {
            var item = listViewItems.SelectedItems[0];
            return (item.SubItems[0].Text, item.SubItems[1].Text).Some();
         }
         else
         {
            return none<(string, string)>();
         }
      }

      protected Maybe<string> getTextItem(string key)
      {
         if (keyToIndexes.Map(key).If(out var index))
         {
            var item = listViewItems.Items[index];
            return item.SubItems[1].Text.Some();
         }
         else
         {
            return none<string>();
         }
      }

      protected void textValue_TextChanged(object sender, EventArgs e)
      {
         var _result =
            from lineItem in getLineItem()
            from key in labelToKeys.Map(lineItem.label)
            from itemType in itemTypes.Map(lineItem.label)
            from stringSet in keyToList.Map(key)
            select (stringSet, itemType);
         if (_result.If(out var set, out var type) && type == ItemType.List)
         {
            var text = textValue.Text;
            if (set.Contains(text))
            {
            }
            else if (set.FirstStartsWith(text).If(out var fullValue))
            {
               textValue.Text = fullValue;
               textValue.Select(text.Length, textValue.Text.Length - text.Length);
            }
         }
      }

      protected AutoStringHash getReplacements()
      {
         var replacements = new AutoStringHash(true, string.Empty);

         foreach (var (key, index) in keyToIndexes)
         {
            var item = listViewItems.Items[index];
            replacements[key] = item.SubItems[1].Text;
         }

         return replacements;
      }

      protected void openEmail(string fileName) => openEmailFrom(fileName, Enumerable.Empty<string>()).OnFailure(e => showException(e));

      protected Result<Unit> openEmailFrom(string fileName, IEnumerable<string> attachments)
      {
         try
         {
            var replacements = getReplacements();

            var resources = new Resources<ReleasePalette>();
            var source = resources.String(fileName);
            var generator = new EmailGenerator(source, personal);

            return generator.Generate(replacements, attachments);
         }
         catch (Exception exception)
         {
            return failure<Unit>(exception);
         }
      }

      protected void openAppointment(string fileName) => openAppointmentFrom(fileName, Enumerable.Empty<string>()).OnFailure(e => showException(e));

      protected Result<Unit> openAppointmentFrom(string fileName, IEnumerable<string> attachments)
      {
         try
         {
            var replacements = getReplacements();

            var resources = new Resources<ReleasePalette>();
            var source = resources.String(fileName);
            var generator = new AppointmentGenerator(source, personal);

            return generator.Generate(replacements, attachments);
         }
         catch (Exception exception)
         {
            return failure<Unit>(exception);
         }
      }

      protected void refreshDbEmail() => openEmail("RefreshDb.txt");

      protected void migrateDbEmail() => openEmail("DbMigration.txt");

      protected void deployEnvironmentEmail() => openEmail("Deploy.txt");

      protected void releaseNotesEmail() => openEmail("Release note.txt");

      protected void requestSecurityReviewEmail() => openEmail("Security.txt");

      protected void requestPsrRunEmail() => openEmail("PsrRun.txt");

      protected void scheduleDeploymentEmail() => openEmail("ScheduleDeployment.txt");

      protected void postDeploymentValidationEmail()
      {
         if (getTextItem("build").If(out var build))
         {
            FolderName tempFolder = @"C:\Temp";
            var tempBuildFolder = tempFolder[build];
            if (tempBuildFolder.Exists())
            {
               var attachments = new List<string> { (tempBuildFolder + $"{build}.log").FullPath };
               if (tempBuildFolder.Files.FirstOrNone(f => f.Name.StartsWith(build) && f.Extension == ".xlsx").If(out var excelFile))
               {
                  attachments.Add(excelFile.FullPath);
               }

               openEmailFrom("PostDeployment.txt", attachments);
            }
         }
      }

      protected void postDeploymentRequestEmail() => openAppointment("DeployPostDeployment.txt");

      protected void closedEmail() => openEmail("Closed.txt");

      protected void ToDevelopEmail() => openEmail("ToDevelop.txt");
   }
}