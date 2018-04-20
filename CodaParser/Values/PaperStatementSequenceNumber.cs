using CodaParser.Exceptions;

namespace CodaParser.Values
{
    public class PaperStatementSequenceNumber
    {
        public int Value;

        public PaperStatementSequenceNumber(string paperStatementSequenceNumber)
        {
            Helpers.ValidateStringLength(paperStatementSequenceNumber, 3, "PaperStatementSequenceNumber");
            Helpers.ValidateStringDigitOnly(paperStatementSequenceNumber, "PaperStatementSequenceNumber");

            var value = int.Parse(paperStatementSequenceNumber);
            if (value < 0)
            {
                throw new InvalidValueException("PaperStatementSequenceNumber", paperStatementSequenceNumber, "Value cannot be negative");
            }

            Value = value;
        }
    }
}