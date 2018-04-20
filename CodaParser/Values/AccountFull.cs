namespace CodaParser.Values
{
    public class AccountFull
    {
        public AccountFull(string value)
        {
            Helpers.ValidateStringLength(value, 37, "AccountFull");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}