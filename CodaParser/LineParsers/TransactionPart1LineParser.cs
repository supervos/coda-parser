using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the transaction movement information line part.
    /// /// </summary>
    public class TransactionPart1LineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 2) == "21";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            var transactionCode = new TransactionCode(codaLine.Substring(53, 8));

            return new TransactionPart1Line(
                new SequenceNumber(codaLine.Substring(2, 4)),
                new SequenceNumberDetail(codaLine.Substring(6, 4)),
                new BankReference(codaLine.Substring(10, 21)),
                new Amount(codaLine.Substring(31, 1) + codaLine.Substring(32, 15), true),
                new Date(codaLine.Substring(47, 6)),
                transactionCode,
                new MessageOrStructuredMessage(codaLine.Substring(61, 54), transactionCode),
                new Date(codaLine.Substring(115, 6)),
                new StatementSequenceNumber(codaLine.Substring(121, 3)),
                new GlobalizationCode(codaLine.Substring(124, 1))
            );
        }
    }
}