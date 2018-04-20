namespace CodaParser.Lines
{
    /// <summary>
    /// The type of a line.
    /// </summary>
    public enum LineType
    {
        /// <summary>
        /// The header record (00).
        /// </summary>
        Identification = 00,

        /// <summary>
        /// The old balance record (10).
        /// </summary>
        InitialState = 10,

        /// <summary>
        /// The first movement record (21).
        /// </summary>
        TransactionPart1 = 21,

        /// <summary>
        /// The second movement record (22).
        /// </summary>
        TransactionPart2 = 22,

        /// <summary>
        /// The thrid movement record (23).
        /// </summary>
        TransactionPart3 = 23,

        /// <summary>
        /// The first information record (31).
        /// </summary>
        InformationPart1 = 31,

        /// <summary>
        /// The second information record (32).
        /// </summary>
        InformationPart2 = 32,

        /// <summary>
        /// The third information record (33).
        /// </summary>
        InformationPart3 = 33,

        /// <summary>
        /// The free communication record (40).
        /// </summary>
        Message = 40,

        /// <summary>
        /// The new balance record (80).
        /// </summary>
        NewState = 80,

        /// <summary>
        /// The trailer record (90).
        /// </summary>
        EndSummary = 90,
    }
}