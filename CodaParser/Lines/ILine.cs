namespace CodaParser.Lines
{
    /// <summary>
    /// Information about a line in a coda format.
    /// </summary>
    public interface ILine
    {
        /// <summary>
        /// Gets the type of the line.
        /// </summary>
        /// <returns>The type that this line represents.</returns>
        LineType GetLineType();
    }
}