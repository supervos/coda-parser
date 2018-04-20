namespace CodaParser.Statements
{
    /// <summary>
    /// Information about the account of the other party.
    /// </summary>
    public class AccountOtherParty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountOtherParty"/> class.
        /// </summary>
        /// <param name="name">The counterparty's name.</param>
        /// <param name="bic">The counterparty's bic.</param>
        /// <param name="number">The counterparty's account number.</param>
        /// <param name="currencyCode">The counterparty's currency code.</param>
        public AccountOtherParty(string name, string bic, string number, string currencyCode)
        {
            Name = name;
            Bic = bic;
            Number = number;
            CurrencyCode = currencyCode;
        }

        /// <summary>
        /// Gets the counterparty's bic.
        /// </summary>
        public string Bic { get; }

        /// <summary>
        /// Gets the counterparty's currency code.
        /// </summary>
        public string CurrencyCode { get; }

        /// <summary>
        /// Gets the counterparty's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the counterparty's account number.
        /// </summary>
        public string Number { get; }
    }
}