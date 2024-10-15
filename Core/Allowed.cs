using Inventory.Abstractions;
using Inventory.ItemCategories;

namespace Inventory
{
    public sealed class Allowed
    {
        private readonly List<Type> _allowedItems = [];
        public static Allowed All => new(typeof(IItem));
        public static Allowed AllPouches => new(typeof(IPouch));
        public static Allowed SmallPouches => new(typeof(ISmallPouch));
        public static Allowed MediumPouches => new(typeof(IMediumPouch));
        public static Allowed LargePouches => new(typeof(ILargePouch));
        public static Allowed Medical => new(typeof(IMedical));
        public static Allowed PistolMainGrips => new(typeof(IPistolGripAttachment));
        public static Allowed PistolMuzzle => new(typeof(IPistolMuzzleAttachment));

        private Allowed(params Type[] types)
        {
            foreach (Type type in types)
            {
                if (typeof(IItem).IsAssignableFrom(type))
                    _allowedItems.Add(type);
                else
                    throw new ArgumentException($"{type.FullName} does not implement IItem.");
            }
        }
        
        public Allowed Add<T>() where T : IItem
        {
            Type type = typeof(T);
            
            if (!_allowedItems.Contains(type))
                _allowedItems.Add(type);
            
            return this;
        }
        
        public Allowed Remove<T>() where T : IItem
        {
            Type type = typeof(T);
            
            if (!_allowedItems.Contains(type))
                _allowedItems.Remove(type);
            
            return this;
        }
        
        public bool IsAllowed(IItem? item)
        {
            if (item == null) 
                return false;
            
            return _allowedItems.Any(type => type.IsInstanceOfType(item));
        }
    }
}