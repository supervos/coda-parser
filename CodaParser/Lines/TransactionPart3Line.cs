using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Continued information about the movement.
    /// </summary>
    public class TransactionPart3Line : IInformationOrTransactionLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionPart3Line"/> class.
        /// </summary>
        /// <param name="sequenceNumber">The continuous sequence number.</param>
        /// <param name="sequenceNumberDetail">The detail number.</param>
        /// <param name="otherAccountNumberAndCurrency">The counterparty's account number and currency code.</param>
        /// <param name="otherAccountName">The counterparty's name.</param>
        /// <param name="message">The communication.</param>
        public TransactionPart3Line(
            SequenceNumber sequenceNumber,
            SequenceNumberDetail sequenceNumberDetail,
            AccountFull otherAccountNumberAndCurrency,
            AccountName otherAccountName,
            Message message)
        {
            SequenceNumber = sequenceNumber;
            SequenceNumberDetail = sequenceNumberDetail;
            OtherAccountNumberAndCurrency = otherAccountNumberAndCurrency;
            OtherAccountName = otherAccountName;
            Message = message;
        }

        /// <inheritdoc />
        public Message Message { get; }

        /// <summary>
        /// Gets the counterparty's name.
        /// </summary>
        public AccountName OtherAccountName { get; }

        /// <summary>
        /// Gets the counterparty's account number and currency code.
        /// </summary>
        public AccountFull OtherAccountNumberAndCurrency { get; }

        /// <inheritdoc />
        public SequenceNumber SequenceNumber { get; }

        /// <summary>
        /// The detail number.
        /// </summary>
        public SequenceNumberDetail SequenceNumberDetail { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.TransactionPart3;
        }
    }
}