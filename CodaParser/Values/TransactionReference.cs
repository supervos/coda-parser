namespace CodaParser.Values
{
    public class TransactionReference
    {
        public string Value;

        public TransactionReference(string value)
        {
            Helpers.ValidateStringLength(value, 16, "TransactionReference");

            Value = value.Trim();
        }
    }
}