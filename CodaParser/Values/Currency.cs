namespace CodaParser.Values
{
    public class Currency
    {
        public Currency(string currencyCode)
        {
            CurrencyCode = currencyCode;
        }

        public string CurrencyCode { get; }
    }
}