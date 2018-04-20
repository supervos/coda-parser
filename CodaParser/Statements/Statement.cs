using System;
using System.Collections.Generic;
using System.Linq;

namespace CodaParser.Statements
{
    /// <summary>
    /// A statement for a change in the balance..
    /// </summary>
    public class Statement
    {
        /// <summary>
        /// Initializes a new <see cref="Statement"/> class.
        /// </summary>
        /// <param name="date">The execution date.</param>
        /// <param name="account">The changed account.</param>
        /// <param name="initialBalance">The initial balance.</param>
        /// <param name="newBalance">The new balance.</param>
        /// <param name="informationalMessage">An informational message.</param>
        /// <param name="transactions">The executed transactions.</param>
        public Statement(DateTime date, Account account, decimal initialBalance, decimal newBalance, string informationalMessage, IEnumerable<Transaction> transactions)
        {
            Date = date;
            Account = account;
            InitialBalance = initialBalance;
            NewBalance = newBalance;
            InformationalMessage = informationalMessage;
            Transactions = Array.AsReadOnly(transactions.ToArray());
        }

        /// <summary>
        /// Gets the changed account.
        /// </summary>
        public Account Account { get; }

        /// <summary>
        /// Gets the execution date.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Gets the informational message.
        /// </summary>
        public string InformationalMessage { get; }

        /// <summary>
        /// Gets the initial balance.
        /// </summary>
        public decimal InitialBalance { get; }

        /// <summary>
        /// Gets the new balance.
        /// </summary>
        public decimal NewBalance { get; }

        /// <summary>
        /// Gets the executed transactions.
        /// </summary>
        public IEnumerable<Transaction> Transactions { get; }
    }
}