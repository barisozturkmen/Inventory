namespace Inventory.Interactions
{
    public class InteractionResult
    {
        protected Interaction Result { get; set; }

        private InteractionResult(Interaction result)
        {
            Result = result;
        }
        
        public static InteractionResult Cancel => new InteractionResult(Interaction.Cancel);
        public static InteractionResult Fail => new InteractionResult(Interaction.Fail);
        public static InteractionResult ItemMoved => new InteractionResult(Interaction.ItemMoved);
    }

    public enum Interaction
    {
        Cancel,
        Fail,
        ItemMoved,
    }
}

