using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// The details of the trailer record.
    /// </summary>
    public class EndSummaryLine : ILine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndSummaryLine"/> class.
        /// </summary>
        /// <param name="debetAmount">The debit movement.</param>
        /// <param name="creditAmount">The credit movement.</param>
        public EndSummaryLine(Amount debetAmount, Amount creditAmount)
        {
            DebetAmount = debetAmount;
            CreditAmount = creditAmount;
        }

        /// <summary>
        /// Gets the credit movement.
        /// </summary>
        public Amount CreditAmount { get; }

        /// <summary>
        /// Gets the debit movement.
        /// </summary>
        public Amount DebetAmount { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.EndSummary;
        }
    }
}