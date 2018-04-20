using CodaParser.Exceptions;

namespace CodaParser.Values
{
    public class SequenceNumberDetail
    {
        public SequenceNumberDetail(string sequenceNumberDetail)
        {
            Helpers.ValidateStringLength(sequenceNumberDetail, 4, "SequenceNumberDetail");
            Helpers.ValidateStringDigitOnly(sequenceNumberDetail, "SequenceNumberDetail");

            var value = int.Parse(sequenceNumberDetail);
            if (value < 0)
            {
                throw new InvalidValueException("SequenceNumberDetail", sequenceNumberDetail, "Value cannot be negative");
            }

            Value = value;
        }

        public int Value { get; }
    }
}