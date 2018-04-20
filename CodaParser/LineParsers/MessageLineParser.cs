using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the free communication lines.
    /// /// </summary>
    public class MessageLineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 1) == "4";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new MessageLine(
                new SequenceNumber(codaLine.Substring(2, 4)),
                new SequenceNumberDetail(codaLine.Substring(6, 4)),
                new Message(codaLine.Substring(32, 80))
            );
        }
    }
}