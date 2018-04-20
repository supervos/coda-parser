namespace CodaParser.Values
{
    public class ApplicationCode
    {
        public ApplicationCode(string value)
        {
            Helpers.ValidateStringLength(value, 2, "ApplicationCode");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}