namespace CodaParser.Values
{
    public class Bic
    {
        public Bic(string value)
        {
            Helpers.ValidateStringLength(value, 11, "Bic");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}