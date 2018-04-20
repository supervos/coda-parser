namespace CodaParser.Values
{
    public class BankReference
    {
        public BankReference(string value)
        {
            Helpers.ValidateStringLength(value, 21, "BankReference");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}