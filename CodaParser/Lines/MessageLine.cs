using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// The free communication.
    /// </summary>
    public class MessageLine : ILine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageLine"/> class.
        /// </summary>
        /// <param name="sequenceNumber">The continuous sequence number.</param>
        /// <param name="sequenceNumberDetail">The detail number.</param>
        /// <param name="content">The text of the free communication.</param>
        public MessageLine(
            SequenceNumber sequenceNumber,
            SequenceNumberDetail sequenceNumberDetail,
            Message content)
        {
            SequenceNumber = sequenceNumber;
            SequenceNumberDetail = sequenceNumberDetail;
            Content = content;
        }

        /// <summary>
        /// Gets the text of the free communication.
        /// </summary>
        public Message Content { get; }

        /// <summary>
        /// Gets the continuous sequence number.
        /// </summary>
        public SequenceNumber SequenceNumber { get; }

        /// <summary>
        /// Gets the detail number.
        /// </summary>
        public SequenceNumberDetail SequenceNumberDetail { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.Message;
        }
    }
}