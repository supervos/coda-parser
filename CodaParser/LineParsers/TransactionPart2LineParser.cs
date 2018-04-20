using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the second transaction movement information line part.
    /// /// </summary>
    public class TransactionPart2LineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 2) == "22";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new TransactionPart2Line(
                new SequenceNumber(codaLine.Substring(2, 4)),
                new SequenceNumberDetail(codaLine.Substring(6, 4)),
                new Message(codaLine.Substring(10, 53)),
                new ClientReference(codaLine.Substring(63, 35)),
                new Bic(codaLine.Substring(98, 11)),
                new TransactionCodeType(codaLine.Substring(112, 1)),
                new IsoReasonReturnCode(codaLine.Substring(113, 4)),
                new CategoryPurpose(codaLine.Substring(117, 4)),
                new Purpose(codaLine.Substring(121, 4))
            );
        }
    }
}