using Inventory.Abstractions;
using Inventory.Interactions;

namespace Inventory.Services
{
    public interface IItemInteractionService
    {
        void GetOptions(IItem item);
        void HandleSelect(InteractionSelection selection);
        bool HandleTargetOption(InteractionSelection selection, InteractionDestination destination);
        void HandleExecute(InteractionSelection selection, KnownDestination destination);
    }
}