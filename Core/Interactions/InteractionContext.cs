using Inventory.Abstractions;

namespace Inventory.Interactions
{
    public static class InteractionContext
    {
        public static InteractionSelection? Selection { get; set; }
        public static IContainer? HoveredTarget { get; set; }
        public static InteractionDestination? Target { get; set; }

        public static void Select(InteractionSelection selection)
        {
            Clear();
            Selection = selection;
        }

        public static void SetTarget(InteractionDestination destination)
        {
            Target = destination;
        }

        private static void Clear()
        {
            Selection = null;
            Target = null;
        }
    }
}