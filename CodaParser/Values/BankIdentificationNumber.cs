namespace CodaParser.Values
{
    public class BankIdentificationNumber
    {
        public BankIdentificationNumber(string value)
        {
            Helpers.ValidateStringLength(value, 3, "BankIdentificationNumber");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}