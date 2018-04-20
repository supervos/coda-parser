namespace CodaParser.Values
{
    public class ExternalApplicationCode
    {
        public ExternalApplicationCode(string value)
        {
            Helpers.ValidateStringLength(value, 5, "ExternalApplicationCode");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}