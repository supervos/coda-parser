namespace CodaParser.Values
{
    public class SepaDirectDebit
    {
        public SepaDirectDebit(string value)
        {
            Helpers.ValidateStringMultipleLengths(value, new[] { 50, 70 }, "SepaDirectDebit");

            SettlementDate = new Date(value.Substring(0, 6));
            Type = int.Parse(value.Substring(6, 1));
            Scheme = int.Parse(value.Substring(7, 1));
            PaidReason = int.Parse(value.Substring(8, 1));
            CreditorIdentificationCode = Helpers.GetTrimmedData(value, 9, 35);
            MandateReference = Helpers.GetTrimmedData(value, 44); //, 35);
        }

        public string CreditorIdentificationCode { get; }

        public string MandateReference { get; }

        public int PaidReason { get; }

        public int Scheme { get; }

        public Date SettlementDate { get; }

        public int Type { get; }
    }
}