using System;
using System.Collections.Generic;
using System.Linq;
using CodaParser.Lines;
using CodaParser.Statements;
using CodaParser.Values;

namespace CodaParser.StatementParsers
{
    /// <summary>
    /// Parser of a transaction.
    /// </summary>
    public class TransactionParser
    {
        /// <summary>
        /// Parse the relevant lines into a <see cref="Transaction"/>.
        /// </summary>
        /// <param name="lines">The lines to parse.</param>
        /// <returns>A single <see cref="Transaction"/>.</returns>
        public Transaction Parse(IEnumerable<ILine> lines)
        {
            var transactionPart1Line = Helpers.GetFirstLineOfType<TransactionPart1Line>(lines);

            var transactionDate = new DateTime(1, 1, 1);
            var valutaDate = new DateTime(1, 1, 1);
            var amount = 0.0m;
            SepaDirectDebit sepaDirectDebit = null;

            var statementSequence = 0;
            var transactionSequence = 0;
            if (transactionPart1Line != null)
            {
                valutaDate = transactionPart1Line.ValutaDate.Value;
                transactionDate = transactionPart1Line.TransactionDate.Value;
                amount = transactionPart1Line.Amount.Value;
                statementSequence = transactionPart1Line.StatementSequenceNumber.Value;
                transactionSequence = transactionPart1Line.SequenceNumber.Value;
                if (transactionPart1Line.MessageOrStructuredMessage.StructuredMessage != null)
                {
                    sepaDirectDebit = transactionPart1Line.MessageOrStructuredMessage.StructuredMessage.SepaDirectDebit;
                }
            }

            var informationPart1Line = Helpers.GetFirstLineOfType<InformationPart1Line>(lines);

            var structuredMessage = "";
            if (!string.IsNullOrEmpty(transactionPart1Line?.MessageOrStructuredMessage.StructuredMessage?.Value))
            {
                structuredMessage = transactionPart1Line.MessageOrStructuredMessage.StructuredMessage.Value;
            }
            else if (!string.IsNullOrEmpty(informationPart1Line?.MessageOrStructuredMessage.StructuredMessage?.Value))
            {
                structuredMessage = informationPart1Line.MessageOrStructuredMessage.StructuredMessage.Value;
            }

            var linesWithAccountInfo = Helpers.FilterLinesOfTypes(
                lines,
                new[]
                {
                    LineType.TransactionPart2,
                    LineType.TransactionPart3
                });

            var accountOtherPartyParser = new AccountOtherPartyParser();
            var account = accountOtherPartyParser.Parse(linesWithAccountInfo);

            var message = ConstructMessage(lines);

            // Extract client reference when available
            string clientReference = null;
            var transactionPart2Line = Helpers.GetFirstLineOfType<TransactionPart2Line>(lines);
            if (transactionPart2Line != null && transactionPart2Line.ClientReference != null)
                clientReference = transactionPart2Line.ClientReference.Value;

            return new Transaction(
                account,
                statementSequence,
                transactionSequence,
                transactionDate,
                valutaDate,
                amount,
                message,
                structuredMessage,
                clientReference,
                sepaDirectDebit);
        }

        private string ConstructMessage(IEnumerable<ILine> lines)
        {
            var transactionLines = Helpers.FilterLinesOfTypes(
                lines,
                new[]
                {
                    LineType.TransactionPart1,
                    LineType.TransactionPart2,
                    LineType.TransactionPart3
                });

            var message = string.Join("", transactionLines.Select(line =>
            {
                Message m = null;
                switch (line)
                {
                    case TransactionPart1Line l:
                        m = l.MessageOrStructuredMessage.Message;
                        break;

                    case TransactionPart2Line l:
                        m = l.Message;
                        break;

                    case TransactionPart3Line l:
                        m = l.Message;
                        break;

                    default:
                        throw new InvalidOperationException("Don't know how to get the message of an object of type " + line.GetType().Name);
                }

                return m?.Value ?? "";
            }));

            if (string.IsNullOrEmpty(message))
            {
                var transactionLine = Helpers.GetFirstLineOfType<TransactionPart2Line>(lines);
                if (transactionLine != null && !string.IsNullOrEmpty(transactionLine.ClientReference.Value))
                {
                    message = transactionLine.ClientReference.Value;
                }

                var informationLines = Helpers.FilterLinesOfTypes(
                    lines,
                    new[]
                    {
                        LineType.InformationPart1,
                        LineType.InformationPart2,
                        LineType.InformationPart3
                    });

                if (!string.IsNullOrEmpty(message))
                {
                    message += " ";
                }

                message += string.Join("", informationLines.Select(line =>
                {
                    Message m = null;
                    switch (line)
                    {
                        case InformationPart1Line i:
                            m = i.MessageOrStructuredMessage.Message;
                            break;

                        case InformationPart2Line i:
                            m = i.Message;
                            break;

                        case InformationPart3Line i:
                            m = i.Message;
                            break;

                        default:
                            throw new InvalidOperationException("Don't know how to get the message of an object of type " + line.GetType().Name);
                    }

                    return m?.Value ?? "";
                }));
            }

            return message.Trim();
        }
    }
}