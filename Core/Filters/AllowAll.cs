using Inventory.Interfaces;

namespace Inventory.Filters
{
    public class AllowAll : IFilter
    {
        public bool IsItemAllowed(IItem item)
        {
            return true;
        }
    }
}