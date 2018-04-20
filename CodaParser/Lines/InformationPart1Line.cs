using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Information about a line.
    /// </summary>
    public class InformationPart1Line : IInformationOrTransactionLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationPart1Line"/> class.
        /// </summary>
        /// <param name="sequenceNumber">The continous sequence number</param>
        /// <param name="sequenceNumberDetail">The detail number.</param>
        /// <param name="bankReference">The reference number added by the bank.</param>
        /// <param name="transactionCode">The transaction code.</param>
        /// <param name="messageOrStructuredMessage">The communication in structured or unstructered format.</param>
        public InformationPart1Line(
            SequenceNumber sequenceNumber,
            SequenceNumberDetail sequenceNumberDetail,
            BankReference bankReference,
            TransactionCode transactionCode,
            MessageOrStructuredMessage messageOrStructuredMessage)
        {
            SequenceNumber = sequenceNumber;
            SequenceNumberDetail = sequenceNumberDetail;
            BankReference = bankReference;
            TransactionCode = transactionCode;
            MessageOrStructuredMessage = messageOrStructuredMessage;
        }

        /// <summary>
        /// Gets the reference number added by the bank.
        /// </summary>
        public BankReference BankReference { get; }

        /// <inheritdoc />
        Message IInformationOrTransactionLine.Message => MessageOrStructuredMessage.Message;

        /// <summary>
        /// Gets the communication in structured or unstructered format.
        /// </summary>
        public MessageOrStructuredMessage MessageOrStructuredMessage { get; }

        /// <inheritdoc />
        public SequenceNumber SequenceNumber { get; }

        /// <summary>
        /// Gets the detail number.
        /// </summary>
        public SequenceNumberDetail SequenceNumberDetail { get; }

        /// <summary>
        /// Gets the transaction code.
        /// </summary>
        public TransactionCode TransactionCode { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.InformationPart1;
        }
    }
}