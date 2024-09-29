namespace Inventory.Interactions
{
    public class InteractionFeedback
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public static InteractionFeedback Success => new InteractionFeedback(true, string.Empty);

        public InteractionFeedback(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}