namespace CodaParser.Statements
{
    public class TransactionCode
    {
        public TransactionCode(
            string family,
            string type,
            string operation,
            string category)
        {
            Family = family;
            Type = type;
            Operation = operation;
            Category = category;
        }
	
        public string Family { get; }

        public string Type { get; }

        public string Operation { get; }

        public string Category { get; }
    }
}