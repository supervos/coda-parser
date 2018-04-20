using System.Collections.Generic;
using CodaParser.Lines;
using CodaParser.StatementParsers;
using CodaParser.Statements;

namespace CodaParser
{
    /// <summary>
    /// Parse raw lines to statements.
    /// </summary>
    public class Parser : IParser<Statement>
    {
        private readonly LinesParser _linesParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        public Parser()
        {
            _linesParser = new LinesParser();
        }

        /// <summary>
        /// Group lines of the same transaction togeter.
        /// </summary>
        /// <param name="lines">The lines to group.</param>
        /// <returns>A list of multiple lines that belong together.</returns>
        public IEnumerable<IEnumerable<ILine>> GroupTransactionsPerStatement(IEnumerable<ILine> lines)
        {
            var statements = new Dictionary<int, List<ILine>>();
            var idx = -1;

            foreach (var line in lines)
            {
                if (statements.Count == 0 || line.GetLineType() == LineType.Identification)
                {
                    idx += 1;
                    statements[idx] = new List<ILine>();
                }

                statements[idx].Add(line);
            }

            return statements.Values;
        }

        /// <inheritdoc />
        public IEnumerable<Statement> Parse(IEnumerable<string> codaLines)
        {
            var lines = _linesParser.Parse(codaLines);
            return ConvertToStatements(lines);
        }

        /// <inheritdoc />
        public IEnumerable<Statement> ParseFile(string codaFile)
        {
            var lines = _linesParser.ParseFile(codaFile);
            return ConvertToStatements(lines);
        }

        private IEnumerable<Statement> ConvertToStatements(IEnumerable<ILine> lines)
        {
            var linesGroupedPerStatement = GroupTransactionsPerStatement(lines);

            var statements = new List<Statement>();
            var parser = new StatementParser();
            foreach (var linesForStatement in linesGroupedPerStatement)
            {
                var statement = parser.Parse(linesForStatement);

                statements.Add(statement);
            }

            return statements;
        }
    }
}