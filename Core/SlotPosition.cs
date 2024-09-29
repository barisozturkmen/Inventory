using System;

namespace Inventory
{
    public struct SlotPosition : IEquatable<SlotPosition>
    {
        public SlotPosition(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; private set; }
        public int Row { get; private set; }
        
        public bool Equals(SlotPosition other)
        {
            return Column == other.Column && Row == other.Row;
        }

        public override bool Equals(object? obj)
        {
            return obj is SlotPosition other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }

        public static bool operator ==(SlotPosition left, SlotPosition right) => left.Equals(right);
        public static bool operator !=(SlotPosition left, SlotPosition right) => !(left == right);
    }
}