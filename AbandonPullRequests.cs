using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Collections;
using Core.Monads;
using Tfs.Library;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public partial class AbandonPullRequests : Form
   {
      protected StringHash<PullRequest> pullRequests;
      protected StringSet workItemPaths;
      protected CheckingStatus checkingStatus;

      public AbandonPullRequests()
      {
         InitializeComponent();

         PullRequestId = string.Empty;
         pullRequests = new StringHash<PullRequest>(true);
         workItemPaths = new StringSet(true);
         checkingStatus = CheckingStatus.None;
      }

      public string PullRequestId { get; set; }

      protected void loadPullRequests(bool show)
      {
         labelPullRequestId.Text = $"Pull Request {PullRequestId}";

         if (show)
         {
            Show();
         }

         treeViewPullRequests.BeginUpdate();

         try
         {
            treeViewPullRequests.Nodes.Clear();
            pullRequests.Clear();

            var pullRequest = new PullRequest(PullRequestId, Constants.BASE, Constants.ORGANIZATION, Constants.PROJECT);
            pullRequest.Get().Force();

            var workItems = pullRequest.WorkItems().ToArray();
            progressBar.Minimum = 1;
            progressBar.Maximum = workItems.Length;
            progressBar.Visible = true;

            foreach (var workItem in pullRequest.WorkItems())
            {
               var activePullRequests = workItem.PullRequests().Where(pr => pr.Status == "active").ToArray();

               if (activePullRequests.Length > 0)
               {
                  var workItemNode = treeViewPullRequests.Nodes.Add($"{workItem.WorkItemType} {workItem.Id} {workItem.Title}");
                  workItemPaths.Add(workItemNode.FullPath);

                  foreach (var activePullRequest in activePullRequests)
                  {
                     var key = workItemNode.Nodes.Add($"{activePullRequest.PullRequestId} {activePullRequest.Title}").FullPath;
                     pullRequests[key] = activePullRequest;
                  }

                  workItemNode.Expand();
               }

               progressBar.PerformStep();
               Application.DoEvents();
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message);
         }
         finally
         {
            treeViewPullRequests.EndUpdate();
            progressBar.Visible = false;
         }
      }

      protected void AbandonPullRequests_Load(object sender, EventArgs e)
      {
         loadPullRequests(true);
      }

      protected void treeViewPullRequests_AfterCheck(object sender, TreeViewEventArgs e)
      {
         if (checkingStatus != CheckingStatus.None)
         {
            return;
         }

         var key = e.Node.FullPath;
         if (workItemPaths.Contains(key))
         {
            var isChecked = e.Node.Checked;
            checkingStatus = CheckingStatus.Child;

            foreach (TreeNode node in e.Node.Nodes)
            {
               node.Checked = isChecked;
            }

            if (checkingStatus == CheckingStatus.Child)
            {
               checkingStatus = CheckingStatus.None;
            }
         }
         else if (e.Node.Parent != null)
         {
            checkingStatus = CheckingStatus.Parent;

            e.Node.Parent.Checked = false;

            if (checkingStatus == CheckingStatus.Parent)
            {
               checkingStatus = CheckingStatus.None;
            }
         }
      }

      protected void checkNodes(TreeNode node, Func<bool, bool> changer)
      {
         foreach (TreeNode treeNode in node.Nodes)
         {
            treeNode.Checked = changer(treeNode.Checked);
            foreach (TreeNode childNode in treeNode.Nodes)
            {
               checkNodes(childNode, changer);
            }
         }
      }

      protected void buttonSelectAll_Click(object sender, EventArgs e)
      {
         checkingStatus = CheckingStatus.All;

         foreach (TreeNode node in treeViewPullRequests.Nodes)
         {
            checkNodes(node, _ => true);
         }

         checkingStatus = CheckingStatus.None;
      }

      protected void buttonUnselectAll_Click(object sender, EventArgs e)
      {
         checkingStatus = CheckingStatus.All;

         foreach (TreeNode node in treeViewPullRequests.Nodes)
         {
            checkNodes(node, _ => false);
         }

         checkingStatus = CheckingStatus.None;
      }

      protected void buttonInvertSelection_Click(object sender, EventArgs e)
      {
         checkingStatus = CheckingStatus.All;

         foreach (TreeNode node in treeViewPullRequests.Nodes)
         {
            checkNodes(node, c => !c);
         }

         checkingStatus = CheckingStatus.None;
      }

      protected void addToList(TreeNode node, StringHash<PullRequest> selectedPullRequests)
      {
         foreach (TreeNode treeNode in node.Nodes)
         {
            if (treeNode.Checked && !workItemPaths.Contains(treeNode.FullPath) && pullRequests.If(treeNode.FullPath, out var selectedPullRequest))
            {
               selectedPullRequests[treeNode.FullPath] = selectedPullRequest;
            }

            foreach (TreeNode childNode in treeNode.Nodes)
            {
               addToList(childNode, selectedPullRequests);
            }
         }
      }

      protected Maybe<TreeNode> findNodeByPath(string path)
      {
         IEnumerable<TreeNode> findNodeByPathInChildren(TreeNode node)
         {
            foreach (TreeNode treeNode in node.Nodes)
            {
               if (treeNode.FullPath == path)
               {
                  yield return treeNode;
               }

               foreach (var childNode in findNodeByPathInChildren(treeNode))
               {
                  yield return childNode;
               }
            }
         }

         IEnumerable<TreeNode> findNodeByPathInTree()
         {
            foreach (TreeNode node in treeViewPullRequests.Nodes)
            {
               foreach (var foundNode in findNodeByPathInChildren(node))
               {
                  yield return foundNode;
               }
            }
         }

         var foundNode = findNodeByPathInTree().ToArray();
         return maybe(foundNode.Length >= 1, () => foundNode[0]);
      }

      protected void buttonAbandon_Click(object sender, EventArgs e)
      {
         var selectedPullRequests = new StringHash<PullRequest>(true);
         foreach (TreeNode node in treeViewPullRequests.Nodes)
         {
            addToList(node, selectedPullRequests);
         }

         progressBar.Minimum = 1;
         progressBar.Maximum = selectedPullRequests.Count;
         progressBar.Visible = true;

         foreach (var (fullPath, pullRequest) in selectedPullRequests)
         {
            var _foundNode = findNodeByPath(fullPath);
            Maybe<string> _text;
            if (pullRequest.Abandon().If(out _, out var exception))
            {
               _text = $"PR {pullRequest.PullRequestId} abandoned";
            }
            else
            {
               _text = $"Exception: {exception.Message}";
            }

            if (_foundNode.If(out var foundNode) && _text.If(out var text))
            {
               treeViewPullRequests.SelectedNode = foundNode;
               foundNode.Text = text;
            }

            progressBar.PerformStep();
         }

         progressBar.Visible = false;
      }
   }
}