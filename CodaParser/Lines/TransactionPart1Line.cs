using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Information about the movement.
    /// </summary>
    public class TransactionPart1Line : IInformationOrTransactionLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionPart1Line"/> class.
        /// </summary>
        /// <param name="sequenceNumber">The continious sequence number.</param>
        /// <param name="sequenceNumberDetail">The detail number.</param>
        /// <param name="bankReference">The reference number of the bank.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="valutaDate">The value date.</param>
        /// <param name="transactionCode">The transaction code.</param>
        /// <param name="messageOrStructuredMessage">The communication, structured or unstructured.</param>
        /// <param name="transactionDate">The entry date.</param>
        /// <param name="statementSequenceNumber">The sequence number statement of account on paper.</param>
        /// <param name="globalizationCode">The globalization code.</param>
        public TransactionPart1Line(
            SequenceNumber sequenceNumber,
            SequenceNumberDetail sequenceNumberDetail,
            BankReference bankReference,
            Amount amount,
            Date valutaDate,
            TransactionCode transactionCode,
            MessageOrStructuredMessage messageOrStructuredMessage,
            Date transactionDate,
            StatementSequenceNumber statementSequenceNumber,
            GlobalizationCode globalizationCode)
        {
            SequenceNumber = sequenceNumber;
            SequenceNumberDetail = sequenceNumberDetail;
            BankReference = bankReference;
            Amount = amount;
            ValutaDate = valutaDate;
            TransactionCode = transactionCode;
            MessageOrStructuredMessage = messageOrStructuredMessage;
            TransactionDate = transactionDate;
            StatementSequenceNumber = statementSequenceNumber;
            GlobalizationCode = globalizationCode;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// Gets the reference number of the bank.
        /// </summary>
        public BankReference BankReference { get; }

        /// <summary>
        /// Gets the globalization code.
        /// </summary>
        public GlobalizationCode GlobalizationCode { get; }

        /// <inheritdoc />
        Message IInformationOrTransactionLine.Message => MessageOrStructuredMessage.Message;

        /// <summary>
        /// Gets the communication, structured or unstructured.
        /// </summary>
        public MessageOrStructuredMessage MessageOrStructuredMessage { get; }

        /// <inheritdoc />
        public SequenceNumber SequenceNumber { get; }

        /// <summary>
        /// Gets the detail number.
        /// </summary>
        public SequenceNumberDetail SequenceNumberDetail { get; }

        /// <summary>
        /// Gets the sequence number statement of account on paper.
        /// </summary>
        public StatementSequenceNumber StatementSequenceNumber { get; }

        /// <summary>
        /// Gets the transaction code.
        /// </summary>
        public TransactionCode TransactionCode { get; }

        /// <summary>
        /// Gets the entry date.
        /// </summary>
        public Date TransactionDate { get; }

        /// <summary>
        /// Gets the value date.
        /// </summary>
        public Date ValutaDate { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.TransactionPart1;
        }
    }
}