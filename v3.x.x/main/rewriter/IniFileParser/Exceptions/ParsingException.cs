using System;
using System.Reflection;

namespace Azurlane.IniFileParser.Exceptions
{
    /// <summary>
    ///     Represents an error ococcurred while parsing data
    /// </summary>
    public class ParsingException : Exception
    {
        public ParsingException(string msg)
            : this(msg, 0, string.Empty, null)
        {
        }

        public ParsingException(string msg, Exception innerException)
            : this(msg, 0, string.Empty, innerException)
        {
        }

        public ParsingException(string msg, int lineNumber, string lineValue)
            : this(msg, lineNumber, lineValue, null)
        {
        }

        public ParsingException(string msg, int lineNumber, string lineValue, Exception innerException)
            : base(
                string.Format(
                    "{0} while parsing line number {1} with value \'{2}\' - IniParser version: {3}",
                    msg, lineNumber, lineValue, Assembly.GetExecutingAssembly().GetName().Version),
                innerException)
        {
            LibVersion = Assembly.GetExecutingAssembly().GetName().Version;
            LineNumber = lineNumber;
            LineValue = lineValue;
        }

        public Version LibVersion { get; }
        public int LineNumber { get; }
        public string LineValue { get; }
    }
}