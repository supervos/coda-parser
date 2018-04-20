using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// The new state of the balance.
    /// </summary>
    public class NewStateLine : ILine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewStateLine"/> class.
        /// </summary>
        /// <param name="statementSequenceNumber">The sequence number statement of account on paper.</param>
        /// <param name="account">The account.</param>
        /// <param name="balance">The new balance.</param>
        /// <param name="date">The new balance date.</param>
        public NewStateLine(
            StatementSequenceNumber statementSequenceNumber,
            AccountFull account,
            Amount balance,
            Date date)
        {
            StatementSequenceNumber = statementSequenceNumber;
            Account = account;
            Balance = balance;
            Date = date;
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        public AccountFull Account { get; }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        public Amount Balance { get; }

        /// <summary>
        /// Gets the date.
        /// </summary>
        public Date Date { get; }

        /// <summary>
        /// Gets the sequence number statement of account on paper.
        /// </summary>
        public StatementSequenceNumber StatementSequenceNumber { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.NewState;
        }
    }
}