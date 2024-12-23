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
        /// <param name="statementSequence">The sequence id of the statement.</param>
        /// <param name="transactionSequence">The sequence id of the transaction.</param>
        /// <param name="transactionDate">The date where the transaction is executed.</param>
        /// <param name="valutaDate">The date where the valuta is changed.</param>
        /// <param name="amount">The amount that has been transferred.</param>
        /// <param name="message">A message that is included in the transaction.</param>
        /// <param name="structuredMessage">A structured message.</param>
        /// <param name="clientReference">The client reference.</param>
        /// <param name="sepaDirectDebit">The SEPA direct debit information.</param>
        public Transaction(AccountOtherParty account, int statementSequence, int transactionSequence, DateTime transactionDate, DateTime valutaDate, decimal amount, string message, string structuredMessage, string clientReference, SepaDirectDebit sepaDirectDebit)
        {
            Account = account;
            StatementSequence = statementSequence;
            TransactionSequence = transactionSequence;
            TransactionDate = transactionDate;
            ValutaDate = valutaDate;
            Amount = amount;
            Message = message;
            StructuredMessage = structuredMessage;
            ClientReference = clientReference;
            SepaDirectDebit = sepaDirectDebit;
        }

        /// <summary>
        /// Gets the account of the other party.
        /// </summary>
        public AccountOtherParty Account { get; }

        /// <summary>
        /// Gets the transferred amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the included message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the client reference.
        /// </summary>
        public string ClientReference { get; }

        /// <summary>
        /// Gets the SEPA direct debit information.
        /// </summary>
        public SepaDirectDebit SepaDirectDebit { get; }

        /// <summary>
        /// Gets the sequence id of the statement.
        /// </summary>
        public int StatementSequence { get; }

        /// <summary>
        /// Gets the structured message.
        /// </summary>
        public string StructuredMessage { get; }

        /// <summary>
        /// Gets the date where the transaction is executed.
        /// </summary>
        public DateTime TransactionDate { get; }

        /// <summary>
        /// Gets the sequence id of the transaction.
        /// </summary>
        public int TransactionSequence { get; }

        /// <summary>
        /// Gets the date when the valuta is changed.
        /// </summary>
        public DateTime ValutaDate { get; }
    }
}