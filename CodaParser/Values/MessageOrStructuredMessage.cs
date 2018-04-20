namespace CodaParser.Values
{
    public class MessageOrStructuredMessage
    {
        public MessageOrStructuredMessage(string value, TransactionCode transactionCode)
        {
            Helpers.ValidateStringMultipleLengths(value, new[] { 54, 74 }, "MessageOrStructuredMessage");

            var hasStructuredMessage = value.Substring(0, 1) == "1" ? true : false;
            StructuredMessage = null;
            Message = null;

            if (hasStructuredMessage)
            {
                StructuredMessage = new StructuredMessage(value.Substring(1), transactionCode);
            }
            else
            {
                Message = new Message(value.Substring(1));
            }
        }

        public Message Message { get; }

        public StructuredMessage StructuredMessage { get; }
    }
}