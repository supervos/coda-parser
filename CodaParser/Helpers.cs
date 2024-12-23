using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CodaParser.Exceptions;
using CodaParser.Lines;

namespace CodaParser
{
    /// <summary>
    /// Class with helper methods.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Get a list of all the lines that are of the requested <see cref="LineType" /> type.
        /// </summary>
        /// <param name="lines">The lines to filter.</param>
        /// <param name="types">The types to filter out.</param>
        /// <returns>The filtered list of <see cref="ILine"/>.</returns>
        public static IEnumerable<ILine> FilterLinesOfTypes(IEnumerable<ILine> lines, IEnumerable<LineType> types)
        {
            var typeValues = types.ToList();

            return lines.Where(line => typeValues.Contains(line.GetLineType()));
        }

        ///<summary>Convert a coda date to an iso format.</summary>
        /// <param name="dateCoda">The date in format <c>ddMMyy</c>.</param>
        /// <returns>The date in the format <c>yyyy-MM-dd</c>.</returns>
        public static string FormatDateString(string dateCoda)
        {
            return "20" + dateCoda.Substring(4, 2) + "-" + dateCoda.Substring(2, 2) + "-" + dateCoda.Substring(0, 2);
        }

        /// <summary>
        /// Gets the first line that matches the requested type.
        /// </summary>
        /// <typeparam name="T">The type to filter for.</typeparam>
        /// <param name="lines">The lines to filter.</param>
        /// <returns>The first line that matches the <typeparamref name="T"/> or <see langword="null" /></returns>
        public static T GetFirstLineOfType<T>(IEnumerable<ILine> lines)
            where T : ILine
        {
            return lines.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Get a part of the input string and trim the spaces before returning the result.
        /// </summary>
        /// <param name="data">The value to get the substring from.</param>
        /// <param name="startPosition">The starting position for getting the substring.</param>
        /// <param name="length">The number of characters to get from the data.</param>
        /// <returns>The trimmed requested part of the input.</returns>
        public static string GetTrimmedData(string data, int startPosition, int length)
        {
            return data.Substring(startPosition, length).Trim();
        }

        /// <summary>
        /// Get a part of the input string starting from the requested position till the end and trim the spaces before returning the result.
        /// </summary>
        /// <param name="data">The value to get the substring from.</param>
        /// <param name="startPosition">The starting position for getting the substring.</param>
        /// <returns>The trimmed data from the input.</returns>
        public static string GetTrimmedData(string data, int startPosition)
        {
            return data.Substring(startPosition).Trim();
        }

        /// <summary>
        /// Remove duplicate spaces from the start en end of the input string, leaving only an optional single space.
        /// </summary>
        /// <param name="value">The data to process.</param>
        /// <returns>The value without duplicate spaces in the beginning and end.</returns>
        public static string TrimSpace(string value)
        {
            value = Regex.Replace(value, "^ +", " ");
            value = Regex.Replace(value, " +$", " ");
            if (value == " ")
            {
                value = "";
            }

            return value;
        }

        /// <summary>
        /// Validate that the input string only contains digits, throwing an exception if it doesn't.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="typeName">The type that needs this check, used in the exception.</param>
        public static void ValidateStringDigitOnly(string value, string typeName)
        {
            if (!Regex.IsMatch(value, "^\\d+$"))
            {
                throw new InvalidValueException(typeName, value, "Should contain only numeric values");
            }
        }

        /// <summary>
        /// Validate that the input string is exactly the requested length, throwing an exception if it doesn't.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="expectedLength">The expected length of the value.</param>
        /// <param name="typeName">The type that needs this check, used in the exception.</param>
        public static void ValidateStringLength(string value, int expectedLength, string typeName)
        {
            if (value.Length != expectedLength)
            {
                throw new InvalidValueException(typeName, value, $"Should be {expectedLength} long");
            }
        }

        /// <summary>
        /// Validate that the input string is exactly one of the requested lengths, throwing an exception if it doesn't.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="expectedLengthArray">A list of excepted lengths of the value.</param>
        /// <param name="typeName">The type that needs this check, used in the exception.</param>
        public static void ValidateStringMultipleLengths(string value, IEnumerable<int> expectedLengthArray, string typeName)
        {
            foreach (var expectedLength in expectedLengthArray)
            {
                if (value.Length == expectedLength)
                {
                    return;
                }
            }

            throw new InvalidValueException(typeName, value, "Length not valid");
        }
    }
}