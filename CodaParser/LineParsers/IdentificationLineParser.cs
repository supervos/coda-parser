using CodaParser.Lines;
using CodaParser.Values;

namespace CodaParser.LineParsers
{
    /// <summary>
    /// The parser for the header record of the transaction.
    /// </summary>
    public class IdentificationLineParser : ILineParser
    {
        /// <inheritdoc />
        public bool CanAcceptString(string codaLine)
        {
            return codaLine.Length == 128 && codaLine.Substring(0, 1) == "0";
        }

        /// <inheritdoc />
        public ILine Parse(string codaLine)
        {
            return new IdentificationLine(
                new Date(codaLine.Substring(5, 6)),
                new BankIdentificationNumber(codaLine.Substring(11, 3)),
                codaLine.Substring(16, 1) == "D" ? true : false,
                new ApplicationCode(codaLine.Substring(14, 2)),
                new FileReference(codaLine.Substring(24, 10)),
                new AccountName(codaLine.Substring(34, 26)),
                new Bic(codaLine.Substring(60, 11)),
                new CompanyIdentificationNumber(codaLine.Substring(71, 11)),
                new ExternalApplicationCode(codaLine.Substring(83, 5)),
                new TransactionReference(codaLine.Substring(88, 16)),
                new RelatedReference(codaLine.Substring(104, 16)),
                new VersionCode(codaLine.Substring(127, 1))
            );
        }
    }
}