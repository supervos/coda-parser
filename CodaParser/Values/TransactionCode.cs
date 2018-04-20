namespace CodaParser.Values
{
    public class TransactionCode
    {
        public TransactionCode(string value)
        {
            Helpers.ValidateStringLength(value, 8, "TransactionCode");
            Helpers.ValidateStringDigitOnly(value, "TransactionCode");

            Type = new TransactionCodeType(value.Substring(0, 1));
            Family = new TransactionCodeFamily(value.Substring(1, 2));
            Operation = new TransactionCodeOperation(value.Substring(3, 2));
            Category = new TransactionCodeCategory(value.Substring(5, 3));
        }

        public TransactionCodeCategory Category { get; }

        public TransactionCodeFamily Family { get; }

        public TransactionCodeOperation Operation { get; }

        public TransactionCodeType Type { get; }
    }
}