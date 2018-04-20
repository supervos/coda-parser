namespace CodaParser.Values
{
    public class Amount
    {
        public Amount(string amountAsString, bool includesSign = false)
        {
            Helpers.ValidateStringDigitOnly(amountAsString, "Amount");

            var negative = 1;
            if (includesSign)
            {
                Helpers.ValidateStringLength(amountAsString, 16, "Amount");

                negative = amountAsString.Substring(0, 1) == "1" ? -1 : 1;
                amountAsString = amountAsString.Substring(1, 15);
            }
            else
            {
                Helpers.ValidateStringLength(amountAsString, 15, "Amount");
            }

            Value = decimal.Parse(amountAsString) * negative / 1000;
        }

        public decimal Value { get; }
    }
}