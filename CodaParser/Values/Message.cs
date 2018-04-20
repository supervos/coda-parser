namespace CodaParser.Values
{
    public class Message
    {
        public Message(string value)
        {
            Value = Helpers.TrimSpace(value);
        }

        public string Value { get; }
    }
}