namespace CodaParser.Values
{
    public class FileReference
    {
        public FileReference(string value)
        {
            Helpers.ValidateStringLength(value, 10, "FileReference");

            Value = value.Trim();
        }

        public string Value { get; }
    }
}