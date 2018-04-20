using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the third type information line part.
    /// /// </summary>
    public class InformationPart3LineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 2) == "33";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new InformationPart3Line(
                new SequenceNumber(codaLine.Substring(2, 4)),
                new SequenceNumberDetail(codaLine.Substring(6, 4)),
                new Message(codaLine.Substring(10, 90))
            );
        }
    }
}