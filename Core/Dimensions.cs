namespace Inventory
{
    public struct Dimensions
    {
        public int Columns { get; }
        public int Rows { get; }

        public Dimensions(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }
}