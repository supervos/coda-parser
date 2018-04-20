using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Initial state of the balance.
    /// </summary>
    public class InitialStateLine : ILine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitialStateLine"/> class.
        /// </summary>
        /// <param name="paperStatementSequenceNumber">The sequence number statement of account on paper or Julian date or zeros.</param>
        /// <param name="statementSequenceNumber">The sequence number of the coded statement of account or zeros.</param>
        /// <param name="account">The account.</param>
        /// <param name="balance">The old balance.</param>
        /// <param name="date">The date of the balance.</param>
        public InitialStateLine(
            PaperStatementSequenceNumber paperStatementSequenceNumber,
            StatementSequenceNumber statementSequenceNumber,
            Account account,
            Amount balance,
            Date date)
        {
            PaperStatementSequenceNumber = paperStatementSequenceNumber;
            StatementSequenceNumber = statementSequenceNumber;
            Account = account;
            Balance = balance;
            Date = date;
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        public Account Account { get; }

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
        public PaperStatementSequenceNumber PaperStatementSequenceNumber { get; }

        /// <summary>
        /// Gets the sequence number of the coded statement.
        /// </summary>
        public StatementSequenceNumber StatementSequenceNumber { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.InitialState;
        }
    }
}