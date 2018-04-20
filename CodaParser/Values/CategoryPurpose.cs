namespace CodaParser.Values
{
    public class CategoryPurpose
    {
        public CategoryPurpose(string value)
        {
            Helpers.ValidateStringLength(value, 4, "CategoryPurpose");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}