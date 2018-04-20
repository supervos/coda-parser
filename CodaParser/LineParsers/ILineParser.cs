using CodaParser.Lines;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// Interface for line parsers.
    /// </summary>
    public interface ILineParser
    {
        ///<summary>Check if the parser take into account this type of line.</summary>
        /// <param name="codaLine">The line to check if parsable.</param>
        /// <returns>True if this parser can parse this line.</returns>
        bool CanAcceptString(string codaLine);

        ///<summary>Parse the given string into a more readable object.</summary>
        /// <param name="codaLine">The line to parse.</param>
        /// <returns>The parsed content of the line.</returns>
        ILine Parse(string codaLine);
    }
}