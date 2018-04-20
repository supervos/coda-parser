using System;

namespace CodaParser.Values
{
    public class Date
    {
        public Date(string dateString)
        {
            Helpers.ValidateStringLength(dateString, 6, "Date");
            Helpers.ValidateStringDigitOnly(dateString, "Date");

            Value = DateTime.Parse(Helpers.FormatDateString(dateString));
        }

        public DateTime Value { get; }
    }
}