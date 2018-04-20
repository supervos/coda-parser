using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the first information line part.
    /// /// </summary>
    public class InformationPart1LineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 2) == "31";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            var transactionCode = new TransactionCode(codaLine.Substring(31, 8));

            return new InformationPart1Line(
                new SequenceNumber(codaLine.Substring(2, 4)),
                new SequenceNumberDetail(codaLine.Substring(6, 4)),
                new BankReference(codaLine.Substring(10, 21)),
                transactionCode,
                new MessageOrStructuredMessage(codaLine.Substring(39, 74), transactionCode)
            );
        }
    }
}