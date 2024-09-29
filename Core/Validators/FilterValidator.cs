using Inventory.Interactions;
using Inventory.Interfaces;

namespace Inventory.Validators
{
    public class FilterValidator : IInteractionValidator
    {
        public static bool Validate(InteractionContext context)
        {
            if (context.Target is IRestrictedContainer restrictedContainer)
                return restrictedContainer.IsItemAllowed(context.Item);
            
            return true;
        }
    }
}