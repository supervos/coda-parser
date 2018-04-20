using CodaParser.Exceptions;

namespace CodaParser.Values
{
    public class SequenceNumber
    {
        public SequenceNumber(string sequenceNumber)
        {
            Helpers.ValidateStringLength(sequenceNumber, 4, "SequenceNumber");
            Helpers.ValidateStringDigitOnly(sequenceNumber, "SequenceNumber");

            var value = int.Parse(sequenceNumber);
            if (value < 0)
            {
                throw new InvalidValueException("SequenceNumber", sequenceNumber, "Value cannot be negative");
            }

            Value = value;
        }

        public int Value { get; }
    }
}