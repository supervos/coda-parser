namespace CodaParser.Values
{
    public class RelatedReference
    {
        public RelatedReference(string value)
        {
            Helpers.ValidateStringLength(value, 16, "RelatedReference");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}