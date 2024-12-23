namespace CodaParser.Statements
{
    /// <summary>
    /// Information about an account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="name">The name addressee.</param>
        /// <param name="bic">The bic of the bank holding the account.</param>
        /// <param name="companyIdentificationNumber">The identification number of the Belgium-based account holder</param>
        /// <param name="number">The number of the account.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="description">The description of the account.</param>
        public Account(string name, string bic, string companyIdentificationNumber, string number, string currencyCode, string countryCode, string description)
        {
            Name = name;
            Bic = bic;
            CompanyIdentificationNumber = companyIdentificationNumber;
            Number = number;
            CurrencyCode = currencyCode;
            CountryCode = countryCode;
            Description = description;
        }

        /// <summary>
        /// Gets the bic of the bank holding the account
        /// </summary>
        public string Bic { get; }

        /// <summary>
        /// Gets the identification number of the Belgium-based account holder
        /// </summary>
        public string CompanyIdentificationNumber { get; }

        /// <summary>
        /// Gets the country code.
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// Gets the currency code.
        /// </summary>
        public string CurrencyCode { get; }
        
        /// <summary>
        /// Gets the description of the account.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the name addressee
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the number of the account.
        /// </summary>
        public string Number { get; }
    }
}