using Inventory.Interactions;
using Inventory.Interfaces;

namespace Inventory.Validators
{
    public interface IInteractionValidator
    {
        static bool Validate(InteractionContext context)
        {
            return false;
        }
    }
}