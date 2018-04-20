namespace CodaParser.Values
{
    /// <summary>
    /// The description of an account.
    /// </summary>
    public class AccountDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDescription"/> class.
        /// </summary>
        /// <param name="value">The description of the account.</param>
        public AccountDescription(string value)
        {
            Helpers.ValidateStringLength(value, 35, "AccountDescription");

            Value = value.Trim();
        }

        /// <summary>
        /// Gets the description of the account.
        /// </summary>
        public string Value { get; }
    }
}