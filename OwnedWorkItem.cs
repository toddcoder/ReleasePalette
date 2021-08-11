using System;
using Tfs.Library;

namespace ReleasePalette
{
   public class OwnedWorkItem : IEquatable<OwnedWorkItem>
   {
      public OwnedWorkItem(WorkItem workItem)
      {
         WorkItem = workItem;
         Owned = false;
      }

      public WorkItem WorkItem { get; }

      public bool Owned { get; set; }

      public override string ToString() => $"{WorkItem.Id}: {WorkItem.Title} | {WorkItem.MergedTo}";

      public bool Equals(OwnedWorkItem other) => other is not null && WorkItem.Id == other.WorkItem.Id;

      public override bool Equals(object obj) => obj is OwnedWorkItem other && Equals(other);

      public override int GetHashCode() => WorkItem.Id.GetHashCode();

      public static bool operator ==(OwnedWorkItem left, OwnedWorkItem right) => Equals(left, right);

      public static bool operator !=(OwnedWorkItem left, OwnedWorkItem right) => !Equals(left, right);
   }
}