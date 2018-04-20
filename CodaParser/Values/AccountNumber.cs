namespace CodaParser.Values
{
    public class AccountNumber
    {
        public AccountNumber(string value, bool isIbanNumber)
        {
            Value = value;
            IsIbanNumber = isIbanNumber;
        }

        public bool IsIbanNumber { get; }

        public string Value { get; }
    }
}