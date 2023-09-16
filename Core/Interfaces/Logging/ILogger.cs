namespace Core
{
    /// <summary>
    /// Represents an interface for logging messages asynchronously.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a message asynchronously with the specified log type.
        /// </summary>
        /// <param name="type">The type of log message (e.g., Info, Error, Warning).</param>
        /// <param name="message">The message to be logged.</param>
        void LogAsync(LogType type, string message);
    }
}
