using CodaParser.Values;

namespace CodaParser.Lines
{
    /// <summary>
    /// The contents of the header record.
    /// </summary>
    public class IdentificationLine : ILine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentificationLine"/> class.
        /// </summary>
        /// <param name="creationDate">The creation date.</param>
        /// <param name="bankIdentificationNumber">The bank identification number or zeros.</param>
        /// <param name="isDuplicate">Indication for duplicity.</param>
        /// <param name="applicationCode">The application code</param>
        /// <param name="fileReference">File reference as determined by the bank or blank</param>
        /// <param name="accountName">Name addressee</param>
        /// <param name="accountBic">Bic of the bank holding the account.</param>
        /// <param name="accountCompanyIdentificationNumber">Identification number of the Belgium-based account holder</param>
        /// <param name="externalApplicationCode">code "seperate application"</param>
        /// <param name="transactionReference">Transaction reference or blank.</param>
        /// <param name="relatedReference">Related reference or blank.</param>
        /// <param name="versionCode">The version code.</param>
        public IdentificationLine(
            Date creationDate,
            BankIdentificationNumber bankIdentificationNumber,
            bool isDuplicate,
            ApplicationCode applicationCode,
            FileReference fileReference,
            AccountName accountName,
            Bic accountBic,
            CompanyIdentificationNumber accountCompanyIdentificationNumber,
            ExternalApplicationCode externalApplicationCode,
            TransactionReference transactionReference,
            RelatedReference relatedReference,
            VersionCode versionCode)
        {
            CreationDate = creationDate;
            BankIdentificationNumber = bankIdentificationNumber;
            IsDuplicate = isDuplicate;
            ApplicationCode = applicationCode;
            FileReference = fileReference;
            AccountName = accountName;
            AccountBic = accountBic;
            AccountCompanyIdentificationNumber = accountCompanyIdentificationNumber;
            ExternalApplicationCode = externalApplicationCode;
            TransactionReference = transactionReference;
            RelatedReference = relatedReference;
            VersionCode = versionCode;
        }

        /// <summary>Gets the bic of the bank holding the account.</summary>
        public Bic AccountBic { get; }

        /// <summary>Gets the identification number of the Belgium-based account holder.</summary>
        public CompanyIdentificationNumber AccountCompanyIdentificationNumber { get; }

        /// <summary>Gets the name addressee</summary>
        public AccountName AccountName { get; }

        /// <summary>Gets the application code</summary>
        public ApplicationCode ApplicationCode { get; }

        /// <summary>Gets the bank identification number or zeros.</summary>
        public BankIdentificationNumber BankIdentificationNumber { get; }

        /// <summary>Gets the creation date.</summary>
        public Date CreationDate { get; }

        /// <summary>Gets the code "seperate application"</summary>
        public ExternalApplicationCode ExternalApplicationCode { get; }

        /// <summary>Gets the file reference as determined by the bank or blank</summary>
        public FileReference FileReference { get; }

        /// <summary>Gets a value indicating whether there is duplicity.</summary>
        public bool IsDuplicate { get; }

        /// <summary>Gets the related reference or blank.</summary>
        public RelatedReference RelatedReference { get; }

        /// <summary>Gets the transaction reference or blank.</summary>
        public TransactionReference TransactionReference { get; }

        /// <summary>Gets the version code.</summary>
        public VersionCode VersionCode { get; }

        /// <inheritdoc />
        public LineType GetLineType()
        {
            return LineType.Identification;
        }
    }
}