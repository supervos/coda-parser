using System;
using CodaParser.Values;

namespace CodaParser.Statements
{
    /// <summary>
    /// Information about a single transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="account">The account of the other party.</param>
        /// <param name="transactionDate">The date where the transaction is executed.</param>
        /// <param name="valutaDate">The date where the valuta is changed.</param>
        /// <param name="amount">The amount that has been transfered.</param>
        /// <param name="message">A message that is included in the transaction.</param>
        /// <param name="structuredMessage">A structured message.</param>
        /// <param name="sepaDirectDebit">The sepa direct debit information.</param>
        public Transaction(AccountOtherParty account, DateTime transactionDate, DateTime valutaDate, decimal amount, string message, string structuredMessage, SepaDirectDebit sepaDirectDebit)
        {
            Account = account;
            TransactionDate = transactionDate;
            ValutaDate = valutaDate;
            Amount = amount;
            Message = message;
            StructuredMessage = structuredMessage;
            SepaDirectDebit = sepaDirectDebit;
        }

        /// <summary>
        /// Gets the account of the other party.
        /// </summary>
        public AccountOtherParty Account { get; }

        /// <summary>
        /// Gets the transfered amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the included message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the sepa direct debit information.
        /// </summary>
        public SepaDirectDebit SepaDirectDebit { get; }

        /// <summary>
        /// Gets the structured message.
        /// </summary>
        public string StructuredMessage { get; }

        /// <summary>
        /// Gets the date where the transaction is executed.
        /// </summary>
        public DateTime TransactionDate { get; }

        /// <summary>
        /// Gets the date when the valuta is changed.
        /// </summary>
        public DateTime ValutaDate { get; }
    }
}