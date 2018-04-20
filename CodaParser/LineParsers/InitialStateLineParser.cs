using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the first initial state of the balance.
    /// /// </summary>
    public class InitialStateLineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 1) == "1";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new InitialStateLine(
                new PaperStatementSequenceNumber(codaLine.Substring(125, 3)),
                new StatementSequenceNumber(codaLine.Substring(2, 3)),
                new Account(codaLine.Substring(1, 1), codaLine.Substring(5, 37), codaLine.Substring(64, 61)),
                new Amount(codaLine.Substring(42, 16), true),
                new Date(codaLine.Substring(58, 6))
            );
        }
    }
}