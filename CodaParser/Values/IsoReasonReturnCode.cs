namespace CodaParser.Values
{
    public class IsoReasonReturnCode
    {
        public IsoReasonReturnCode(string value)
        {
            Helpers.ValidateStringLength(value, 4, "IsoReasonReturnCode");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}