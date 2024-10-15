namespace Inventory
{
    public struct Slot : IEquatable<Slot>
    {
        public Slot(SlotPosition position)
        {
            Position = position;
        }

        public Slot(int column, int row)
        {
            Position = new SlotPosition(column, row);
        }
        
        public SlotPosition Position { get; private set; }

        public bool Equals(Slot other)
        {
            return Position.Equals(other.Position);
        }

        public override bool Equals(object? obj)
        {
            return obj is Slot other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
        
        public static bool operator ==(Slot left, Slot right) => left.Equals(right);
        public static bool operator !=(Slot left, Slot right) => !(left == right);
    }
}
