using System.Collections.Generic;
using System.Text;
using CodaParser.Lines;

namespace CodaParser.StatementParsers
{
    /// <summary>
    /// Parser for the message.
    /// </summary>
    public class MessageParser
    {
        /// <summary>
        /// Parse the relevant message lines into a single message.
        /// </summary>
        /// <param name="lines">The lines to parse.</param>
        /// <returns>The message.</returns>
        public string Parse(IEnumerable<MessageLine> lines)
        {
            var messageString = new StringBuilder();

            foreach (var message in lines)
            {
                var trimmedContent = message.Content.Value.Trim();
                if (trimmedContent.Length > 0 && messageString.Length > 0)
                {
                    messageString.Append(" ");
                }

                messageString.Append(trimmedContent);
            }

            return messageString.ToString();
        }
    }
}