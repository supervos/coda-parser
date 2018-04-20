namespace CodaParser.Values
{
    public class ClientReference
    {
        public ClientReference(string value)
        {
            Helpers.ValidateStringLength(value, 35, "ClientReference");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}