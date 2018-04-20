namespace CodaParser.Values
{
    public class Purpose
    {
        public Purpose(string value)
        {
            Helpers.ValidateStringLength(value, 4, "Purpose");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}