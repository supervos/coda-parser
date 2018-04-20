namespace CodaParser.Values
{
    public class TransactionCodeFamily
    {
        public string Value;

        public TransactionCodeFamily(string value)
        {
            Helpers.ValidateStringLength(value, 2, "TransactionCodeFamily");
            Helpers.ValidateStringDigitOnly(value, "TransactionCodeFamily");

            Value = value;
        }
    }
}