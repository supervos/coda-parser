namespace CodaParser.Values
{
    public class TransactionCodeCategory
    {
        public TransactionCodeCategory(string value)
        {
            Helpers.ValidateStringLength(value, 3, "TransactionCodeCategory");

            Value = value;
        }

        public string Value { get; }
    }
}