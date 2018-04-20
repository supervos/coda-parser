using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the trailing record of a transaction.
    /// </summary>
    public class EndSummaryLineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 1) == "9";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new EndSummaryLine(
                new Amount(codaLine.Substring(22, 15)), // taken from the account (=debetomzet)
                new Amount(codaLine.Substring(37, 15)) // added to the account (=creditomzet)
            );
        }
    }
}