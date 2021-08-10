using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Collections;
using Core.Matching;
using Core.WinForms;
using Tfs.Library;

namespace ReleasePalette
{
   public partial class AddWorkItems : Form
   {
      protected Http http;
      protected StringSet existingWorkItemIds;
      private string targetDate;

      public AddWorkItems()
      {
         InitializeComponent();

         PullRequestId = string.Empty;
         targetDate = string.Empty;
         http = new Http { Base = "tfs", Organization = "LS", Project = "Estream" };
         existingWorkItemIds = new StringSet(true);
      }

      public string PullRequestId { get; set; }

      public string TargetDate
      {
         get => targetDate;
         set
         {
            if (value.Matches(@"^(\d+)/(\d+)/(\d+)").If(out var result))
            {
               var (month, day, year) = result;
               targetDate = $"{year.PadLeft(4, '0')}-{month.PadLeft(2, '0')}-{day.PadLeft(2, '0')}";
            }
            else
            {
               targetDate = value;
            }
         }
      }

      protected void loadWorkItems(bool show)
      {
         labelPullRequestId.Text = $"Pull Request {PullRequestId}";

         if (show)
         {
            Show();
         }

         try
         {
            var pullRequest = new PullRequest(PullRequestId, http);
            pullRequest.Get().Force();

            var workItems = pullRequest.WorkItems().Where(i => i.TargetDate.StartsWith(targetDate)).OrderBy(i => i.Id).ToArray();
            loadListView(workItems, listViewExisting);
            existingWorkItemIds.AddRange(workItems.Select(i => i.Id));
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message);
         }
         finally
         {
            listViewExisting.EndUpdate();
         }
      }

      protected void loadListView(IEnumerable<WorkItem> workItems, ListView listView)
      {
         listView.BeginUpdate();

         try
         {
            foreach (var workItem in workItems)
            {
               var item = listView.Items.Add(workItem.Id);
               item.SubItems.Add(workItem.Title);
            }
            listView.AutoSizeColumns();
         }
         catch
         {
         }
         finally
         {
            listView.EndUpdate();
         }
      }

      protected void AddWorkItems_Load(object sender, EventArgs e)
      {
         loadWorkItems(true);
      }
   }
}