using System;

namespace CodaParser.Exceptions
{
    /// <summary>
    /// Exception indicating that there was an invalid value.
    /// </summary>
    public class InvalidValueException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidValueException"/> class.
        /// </summary>
        /// <param name="type">The class that throws the exception.</param>
        /// <param name="value">The value that is invalid.</param>
        /// <param name="errorMessage">The message explaining why the value is invalid.</param>
        public InvalidValueException(string type, object value, string errorMessage)
            : base($"Value \"{value}\" is invalid for type {type} ({errorMessage})")
        {
        }
    }
}