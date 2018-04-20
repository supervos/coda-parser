using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the third transaction movement information line part.
    /// /// </summary>
    public class TransactionPart3LineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 2) == "23";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new TransactionPart3Line(
                new SequenceNumber(codaLine.Substring(2, 4)),
                new SequenceNumberDetail(codaLine.Substring(6, 4)),
                new AccountFull(codaLine.Substring(10, 37)),
                new AccountName(codaLine.Substring(47, 35)),
                new Message(codaLine.Substring(82, 43))
            );
        }
    }
}