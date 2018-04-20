namespace CodaParser.Values
{
    public class AccountNumberType
    {
        public AccountNumberType(string value)
        {
            Helpers.ValidateStringLength(value, 1, "AccountNumberType");

            Value = value;
        }

        public string Value { get; }
    }
}