using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Collections;
using Core.Enumerables;
using Core.Monads;
using Core.Objects;
using Tfs.Library;
using static Core.Monads.MonadFunctions;

namespace ReleasePalette
{
   public partial class MissingWorkItems : Form
   {
      protected Set<OwnedWorkItem> workItems;
      protected Http http;

      public MissingWorkItems()
      {
         InitializeComponent();

         workItems = new Set<OwnedWorkItem>();
         http = new Http { Base = "tfs", Organization = "LS", Project = "Estream" };
         PullRequestId = string.Empty;
         ReleaseBranch = string.Empty;
         ExceptionMessage = none<string>();
      }

      public string PullRequestId { get; set; }

      public string ReleaseBranch { get; set; }

      public Maybe<string> ExceptionMessage { get; set; }

      protected IEnumerable<OwnedWorkItem> getOwnedWorkItems()
      {
         try
         {
            var pullRequest = new PullRequest(PullRequestId, http);
            pullRequest.Get().Force();
            workItems.Clear();
            workItems.AddRange(pullRequest.WorkItems().Select(wi => new OwnedWorkItem(wi) { Owned = true }));

            var query = new WorkItemQuery(http)
            {
               Filter = $"[Estream.ProdSupp.MergeStatus] = 'Merged' AND [Estream.ProdSupp.MergedTo] CONTAINS '{ReleaseBranch}'"
            };
            var mergedWorkItems = query.WorkItems().Select(wi => new OwnedWorkItem(wi)).Where(wi => !workItems.Contains(wi));
            workItems.AddRange(mergedWorkItems);

            return workItems;
         }
         catch (Exception exception)
         {
            ExceptionMessage = exception.Message;
         }
      }

      protected void loadListBox()
      {

      }
   }
}
