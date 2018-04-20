namespace CodaParser.Values
{
    public class GlobalizationCode
    {
        public GlobalizationCode(string value)
        {
            Helpers.ValidateStringLength(value, 1, "GlobalizationCode");

            Value = int.Parse(value);
        }

        public int Value { get; }
    }
}