namespace CodaParser.Values
{
    public class VersionCode
    {
        public VersionCode(string value)
        {
            Helpers.ValidateStringLength(value, 1, "VersionCode");

            Value = value;
        }

        public string Value { get; }
    }
}