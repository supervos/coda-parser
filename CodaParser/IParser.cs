using System.Collections.Generic;

namespace CodaParser
{
    /// <summary>
    /// Interface for parsing list of string or a file to a specific type.
    /// </summary>
    /// <typeparam name="T">The result type of the parsing.</typeparam>
    public interface IParser<out T>
    {
        /// <summary>
        /// Parse a list of strings to their matching type.
        /// </summary>
        /// <param name="codaLines">The strings to parse.</param>
        /// <returns>The parsed result.</returns>
        IEnumerable<T> Parse(IEnumerable<string> codaLines);

        /// <summary>
        /// Read the content of the requested file and parse the content to the matching type.
        /// </summary>
        /// <param name="codaFile">Location of the file to parse.</param>
        /// <returns>The parsed result.</returns>
        IEnumerable<T> ParseFile(string codaFile);
    }
}