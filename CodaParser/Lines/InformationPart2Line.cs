using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Continued information about a line.
    /// </summary>
    public class InformationPart2Line : IInformationOrTransactionLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationPart2Line"/> class.
        /// </summary>
        /// <param name="sequenceNumber">The continuous sequence number.</param>
        /// <param name="sequenceNumberDetail">The detail number.</param>
        /// <param name="message">The communication.</param>
        public InformationPart2Line(
            SequenceNumber sequenceNumber,
            SequenceNumberDetail sequenceNumberDetail,
            Message message)
        {
            SequenceNumber = sequenceNumber;
            SequenceNumberDetail = sequenceNumberDetail;
            Message = message;
        }

        /// <inheritdoc />
        public Message Message { get; }

        /// <inheritdoc />
        public SequenceNumber SequenceNumber { get; }

        /// <summary>
        /// Gets the detail number.
        /// </summary>
        public SequenceNumberDetail SequenceNumberDetail { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.InformationPart2;
        }
    }
}