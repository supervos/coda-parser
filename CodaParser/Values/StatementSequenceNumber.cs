namespace CodaParser.Values
{
    public class StatementSequenceNumber
    {
        public StatementSequenceNumber(string value)
        {
            Helpers.ValidateStringLength(value, 3, "StatementSequenceNumber");
            Helpers.ValidateStringDigitOnly(value, "StatementSequenceNumber");

            Value = int.Parse(value);
        }

        public int Value { get; }
    }
}