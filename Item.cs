using System;

namespace ReleasePalette
{
   public class Item: IEquatable<Item>
   {
      public Item(string label, ItemType type)
      {
         Label = label;
         Type = type;
      }

      public string Label { get; }

      public ItemType Type { get; }

      public bool Equals(Item other) => other is not null && Label == other.Label && Type == other.Type;

      public override bool Equals(object obj) => obj is Item item && Equals(item);

      public override int GetHashCode()
      {
         unchecked
         {
            return (Label?.GetHashCode() ?? 0) * 397 ^ (int)Type;
         }
      }

      public static bool operator ==(Item left, Item right) => Equals(left, right);

      public static bool operator !=(Item left, Item right) => !Equals(left, right);
   }
}