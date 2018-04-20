namespace CodaParser.Values
{
    public class TransactionCodeOperation
    {
        public TransactionCodeOperation(string value)
        {
            Helpers.ValidateStringLength(value, 2, "TransactionCodeOperation");

            Value = value;
        }

        public string Value { get; }
    }
}