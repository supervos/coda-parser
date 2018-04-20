using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the final state of the balance.
    /// /// </summary>
    public class NewStateLineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 1) == "8";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new NewStateLine(
                new StatementSequenceNumber(codaLine.Substring(1, 3)),
                new AccountFull(codaLine.Substring(4, 37)), // don't further parse info as it is already present in coda1-line
                new Amount(codaLine.Substring(41, 16), true),
                new Date(codaLine.Substring(57, 6))
            );
        }
    }
}