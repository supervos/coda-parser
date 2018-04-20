using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodaParser.LineParsers;
using CodaParser.Lines;

namespace CodaParser
{
    /// <summary>
    /// Parse raw strings to a structured line.
    /// </summary>
    public class LinesParser : IParser<ILine>
    {
        private readonly IEnumerable<ILineParser> _lineParsers;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinesParser"/> class.
        /// </summary>
        public LinesParser()
        {
            _lineParsers = InitLineParsers();
        }

        /// <inheritdoc />
        public IEnumerable<ILine> Parse(IEnumerable<string> codaLines)
        {
            var list = new List<ILine>();

            foreach (var line in codaLines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    ILine lineObject = null;

                    foreach (var parser in _lineParsers)
                    {
                        if (parser.CanAcceptString(line))
                        {
                            lineObject = parser.Parse(line);
                            break;
                        }
                    }

                    if (lineObject == null)
                    {
                        throw new Exception("Could not parse");
                    }

                    list.Add(lineObject);
                }
            }

            if (list.Count == 0)
            {
                throw new Exception("No data given");
            }

            return list;
        }

        /// <inheritdoc />
        public IEnumerable<ILine> ParseFile(string codaFile)
        {
            return Parse(FileToCodaLines(codaFile));
        }

        ///<summary>Read contents from file and put every line as an entry in the result array</summary>
        /// <param name="codaFile">The file to read.</param>
        /// <returns>The non-empty lines from the file.</returns>
        private IEnumerable<string> FileToCodaLines(string codaFile)
        {
            return System.IO.File.ReadAllLines(codaFile, Encoding.UTF8).Where(m => !string.IsNullOrEmpty(m));
        }

        /// <summary>
        /// Get an initial list of parsers.
        /// </summary>
        /// <returns>A list of known parsers.</returns>
        private IEnumerable<ILineParser> InitLineParsers()
        {
            return new ILineParser[]
            {
                new IdentificationLineParser(),
                new InitialStateLineParser(),
                new TransactionPart1LineParser(),
                new TransactionPart2LineParser(),
                new TransactionPart3LineParser(),
                new InformationPart1LineParser(),
                new InformationPart2LineParser(),
                new InformationPart3LineParser(),
                new MessageLineParser(),
                new NewStateLineParser(),
                new EndSummaryLineParser(),
            };
        }
    }
}