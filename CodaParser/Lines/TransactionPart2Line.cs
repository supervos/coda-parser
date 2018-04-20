using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Continued information about the movement.
    /// </summary>
    public class TransactionPart2Line : IInformationOrTransactionLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionPart2Line"/> class.
        /// </summary>
        /// <param name="sequenceNumber">The continuous sequence number.</param>
        /// <param name="sequenceNumberDetail">The detail number.</param>
        /// <param name="message">The communication.</param>
        /// <param name="clientReference">The customer reference.</param>
        /// <param name="otherAccountBic">The bic of the counterparty's bank.</param>
        /// <param name="transactionType">The type of the transaction.</param>
        /// <param name="isoReasonReturnCode">The reason return code in iso format.</param>
        /// <param name="categoryPurpose">The category of the purpose.</param>
        /// <param name="purpose">The purpose.</param>
        public TransactionPart2Line(
            SequenceNumber sequenceNumber,
            SequenceNumberDetail sequenceNumberDetail,
            Message message,
            ClientReference clientReference,
            Bic otherAccountBic,
            TransactionCodeType transactionType,
            IsoReasonReturnCode isoReasonReturnCode,
            CategoryPurpose categoryPurpose,
            Purpose purpose)
        {
            SequenceNumber = sequenceNumber;
            SequenceNumberDetail = sequenceNumberDetail;
            Message = message;
            ClientReference = clientReference;
            OtherAccountBic = otherAccountBic;
            TransactionType = transactionType;
            IsoReasonReturnCode = isoReasonReturnCode;
            CategoryPurpose = categoryPurpose;
            Purpose = purpose;
        }

        /// <summary>
        /// Gets the category of the purpose.
        /// </summary>
        public CategoryPurpose CategoryPurpose { get; }

        /// <summary>
        /// Gets the customer reference.
        /// </summary>
        public ClientReference ClientReference { get; }

        /// <summary>
        /// Gets the reason return code in iso format.
        /// </summary>
        public IsoReasonReturnCode IsoReasonReturnCode { get; }

        /// <inheritdoc />
        public Message Message { get; }

        /// <summary>
        /// Gets the bic of the counterparty's bank.
        /// </summary>
        public Bic OtherAccountBic { get; }

        /// <summary>
        /// Gets the purpose.
        /// </summary>
        public Purpose Purpose { get; }

        /// <inheritdoc />
        public SequenceNumber SequenceNumber { get; }

        /// <summary>
        /// Gets the detail number.
        /// </summary>
        public SequenceNumberDetail SequenceNumberDetail { get; }

        /// <summary>
        /// Gets the type of the transaction.
        /// </summary>
        public TransactionCodeType TransactionType { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.TransactionPart2;
        }
    }
}