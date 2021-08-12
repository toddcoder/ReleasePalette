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
         var pullRequest = new PullRequest(PullRequestId, Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT);
         pullRequest.Get().Force();

         foreach (var workItem in pullRequest.WorkItems())
         {
            yield return workItem;

            Application.DoEvents();
         }
      }

      protected IEnumerable<WorkItem> getMissingWorkItems()
      {
         var query = new WorkItemQuery(Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT)
         {
            Filter = $"[Estream.ProdSupp.MergeStatus] = 'Merged' AND [Estream.ProdSupp.MergedTo] CONTAINS '{ReleaseBranch}'"
         };
         foreach (var workItem in query.WorkItems())
         {
            yield return workItem;

            Application.DoEvents();
         }
      }

      protected void loadViews(bool show)
      {
         if (show)
         {
            Show();
         }

         try
         {
            webProgress.Visible = true;
            Application.DoEvents();

            var existing = getExistingWorkItems().ToSet();
            var existingIds = existing.Select(i => i.Id).ToStringSet(true);
            var missing = getMissingWorkItems().ToSet();

            viewExisting.BeginUpdate();
            viewExisting.Items.Clear();

            foreach (var workItem in existing.OrderBy(i => i.Id))
            {
               var item = viewExisting.Items.Add(workItem.Id);
               item.SubItems.Add(workItem.Title);
            }

            viewExisting.AutoSizeColumns();

            viewMissing.BeginUpdate();
            viewMissing.Items.Clear();

            foreach (var workItem in missing.Where(i => !existingIds.Contains(i.Id)).OrderBy(i => i.Id))
            {
               var item = viewMissing.Items.Add(workItem.Id);
               item.SubItems.Add(workItem.Title);
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
            webProgress.Visible = false;
         }
      }

      protected void MissingWorkItems_Load(object sender, EventArgs e)
      {
         labelPullRequestId.Text = $"Pull Request {PullRequestId}";

         loadViews(true);
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

            loadViews(false);
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

      protected void buttonSelectAll_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in viewMissing.Items)
         {
            item.Checked = true;
         }
      }

      protected void buttonUnselectAll_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in viewMissing.Items)
         {
            item.Checked = false;
         }
      }

      protected void buttonInvertSelection_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in viewMissing.Items)
         {
            item.Checked = !item.Checked;
         }
      }

      protected void MissingWorkItems_Resize(object sender, EventArgs e)
      {
         viewExisting.AutoSizeColumns();
         viewMissing.AutoSizeColumns();
      }
   }
}