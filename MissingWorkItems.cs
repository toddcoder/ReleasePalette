using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Enumerables;
using Core.Strings;
using Core.WinForms;
using Tfs.Library;

namespace ReleasePalette
{
   public partial class MissingWorkItems : Form
   {
      public MissingWorkItems()
      {
         InitializeComponent();

         PullRequestId = string.Empty;
         ReleaseBranch = string.Empty;
      }

      public string PullRequestId { get; set; }

      public string ReleaseBranch { get; set; }

      protected IEnumerable<WorkItem> getExistingWorkItems()
      {
         try
         {
            var pullRequest = new PullRequest(PullRequestId, Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT);
            pullRequest.Get().Force();

            return pullRequest.WorkItems();
         }
         catch (Exception exception)
         {
            labelStatus.Text = exception.Message;
            return Enumerable.Empty<WorkItem>();
         }
      }

      protected IEnumerable<WorkItem> getMissingWorkItems()
      {
         try
         {
            var query = new WorkItemQuery(Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT)
            {
               Filter = $"[Estream.ProdSupp.MergeStatus] = 'Merged' AND [Estream.ProdSupp.MergedTo] CONTAINS '{ReleaseBranch}'"
            };
            return query.WorkItems();
         }
         catch (Exception exception)
         {
            labelStatus.Text = exception.Message;
            return Enumerable.Empty<WorkItem>();
         }
      }

      protected void loadViews()
      {
         try
         {
            var existing = getExistingWorkItems().ToSet();
            var existingIds = existing.Select(i => i.Id).ToStringSet(true);
            var missing = getMissingWorkItems().ToSet();

            viewExisting.BeginUpdate();
            viewExisting.Items.Clear();

            foreach (var workItem in existing.OrderBy(i => i.Id))
            {
               var item = viewExisting.Items.Add(workItem.Id);
               item.SubItems.Add(workItem.Title.Truncate(80));
            }

            viewExisting.AutoSizeColumns();

            viewMissing.BeginUpdate();
            viewMissing.Items.Clear();

            foreach (var workItem in missing.Where(i => !existingIds.Contains(i.Id)).OrderBy(i => i.Id))
            {
               var item = viewMissing.Items.Add(workItem.Id);
               item.SubItems.Add(workItem.Title.Truncate(80));
            }

            viewMissing.AutoSizeColumns();

            labelStatus.Text = $"{existing.Count} existing | {viewMissing.Items.Count} missing";
         }
         catch (Exception exception)
         {
            labelStatus.Text = exception.Message;
         }
         finally
         {
            viewExisting.EndUpdate();
            viewMissing.EndUpdate();
         }
      }

      protected void MissingWorkItems_Load(object sender, EventArgs e)
      {
         labelPullRequestId.Text = $"Pull Request {PullRequestId}";

         loadViews();
      }

      protected void buttonAdd_Click(object sender, EventArgs e)
      {
         try
         {
            var pullRequest = new PullRequest(PullRequestId, Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT);
            pullRequest.Get().Force();
            foreach (ListViewItem item in viewMissing.Items)
            {
               if (item.Checked)
               {
                  var id = item.Text;
                  var workItem = new WorkItem(id, Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT);
                  workItem.Get().Force();
                  workItem.AddToPullRequest(pullRequest).Force();
               }
            }

            loadViews();
         }
         catch (Exception exception)
         {
            labelStatus.Text = exception.Message;
         }
      }

      protected void buttonClose_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}