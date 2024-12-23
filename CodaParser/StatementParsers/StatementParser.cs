using System;
using System.Collections.Generic;
using System.Linq;
using CodaParser.Lines;
using CodaParser.Statements;

namespace CodaParser.StatementParsers
{
    /// <summary>
    /// Parser of a single statement.
    /// </summary>
    public class StatementParser
    {
        /// <summary>
        /// Parse the lines into a <see cref="Statement"/>.
        /// </summary>
        /// <param name="lines">The lines to parse.</param>
        /// <returns>A single <see cref="Statement"/>.</returns>
        public Statement Parse(IEnumerable<ILine> lines)
        {
            var date = new DateTime(1, 1, 1);
            var identificationLine = Helpers.GetFirstLineOfType<IdentificationLine>(lines);
            if (identificationLine != null)
            {
                date = identificationLine.CreationDate.Value;
            }

            var initialBalance = 0.0m;
            var sequenceNumber = 0;
            var initialStateLine = Helpers.GetFirstLineOfType<InitialStateLine>(lines);
            if (initialStateLine != null)
            {
                initialBalance = initialStateLine.Balance.Value;
                sequenceNumber = initialStateLine.StatementSequenceNumber.Value;
            }

            var newBalance = 0.0m;
            var newDate = new DateTime(1, 1, 1);
            var newStateLine = Helpers.GetFirstLineOfType<NewStateLine>(lines);
            if (newStateLine != null)
            {
                newBalance = newStateLine.Balance.Value;
                newDate = newStateLine.Date.Value;
            }

            var messageParser = new MessageParser();
            var informationalMessage = messageParser.Parse(lines.OfType<MessageLine>());

            var accountParser = new AccountParser();
            var account = accountParser.Parse(
                Helpers.FilterLinesOfTypes(
                    lines,
                    new[]
                    {
                        LineType.Identification,
                        LineType.InitialState
                    }
                )
            );

            var transactionLines = GroupTransactions(lines.OfType<IInformationOrTransactionLine>());

            var transactionParser = new TransactionParser();
            var transactions = transactionLines.Select(l => transactionParser.Parse(l));

            return new Statement(
                date,
                account,
                sequenceNumber,
                initialBalance,
                newBalance,
                newDate,
                informationalMessage,
                transactions
            );
        }

        private IEnumerable<IEnumerable<IInformationOrTransactionLine>> GroupTransactions(IEnumerable<IInformationOrTransactionLine> lines)
        {
            var transactions = new Dictionary<int, List<IInformationOrTransactionLine>>();
            var idx = -1;
            var sequenceNumber = -1;

            foreach (var transactionOrInformationLine in lines)
            {
                if (transactions.Count == 0 || sequenceNumber != transactionOrInformationLine.SequenceNumber.Value)
                {
                    sequenceNumber = transactionOrInformationLine.SequenceNumber.Value;
                    idx += 1;

                    transactions[idx] = new List<IInformationOrTransactionLine>();
                }

                transactions[idx].Add(transactionOrInformationLine);
            }

            return transactions.Values;
        }
    }
}