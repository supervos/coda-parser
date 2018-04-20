namespace CodaParser.Values
{
    public class Country
    {
        public Country(string countryCode)
        {
            CountryCode = countryCode;
        }

        public string CountryCode { get; }
    }
}