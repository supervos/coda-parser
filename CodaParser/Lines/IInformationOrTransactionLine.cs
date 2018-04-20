using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// Information about an information or a transaction line.
    /// </summary>
    public interface IInformationOrTransactionLine : ILine
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        Message Message { get; }

        /// <summary>
        /// Gets the sequence number.
        /// </summary>
        SequenceNumber SequenceNumber { get; }
    }
}