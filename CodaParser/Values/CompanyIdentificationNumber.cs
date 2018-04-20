namespace CodaParser.Values
{
    public class CompanyIdentificationNumber
    {
        public CompanyIdentificationNumber(string value)
        {
            Helpers.ValidateStringLength(value, 11, "CompanyIdentificationNumber");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}