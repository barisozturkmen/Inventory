using Inventory.Abstractions;
using Inventory.Interactions;

namespace Inventory.Validators
{
    public static class RestrictionValidator
    {
        public static bool ValidateRestriction(this InteractionDestination destination, IItem item)
        {
            bool isValid = false;
            if (destination.Target is IRestrictedContainer restrictedContainer)
                isValid = restrictedContainer.Allowed.IsAllowed(item);
            
            return isValid;
        }
    }
}