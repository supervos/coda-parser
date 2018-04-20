namespace CodaParser.Values
{
    public class TransactionCodeType
    {
        public TransactionCodeType(string value)
        {
            Helpers.ValidateStringLength(value, 1, "TransactionCodeType");

            Value = value;
        }

        public string Value { get; }
    }
}