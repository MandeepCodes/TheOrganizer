using Core;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a simple logger class that logs messages to the console.
    /// </summary>
    public class Logger : WindowBase, ILogger
    {
        /// <summary>
        /// Logs a message asynchronously.
        /// </summary>
        /// <param name="type">The type of log message (e.g., Info, Error, Warning).</param>
        /// <param name="message">The message to be logged.</param>
        public void LogAsync(LogType type, string message)
        {
            string dateTime = DateTime.Now.ToString("dd/MMMM/yyyy hh:mm tt");
            Console.WriteLine(dateTime + ": " + type.ToString() + ": " + message);
        }

        public override bool RegisterClass()
        {
            //load file 
            return true;
        }

        public override bool StartClass()
        {
            return true;
        }
    }
}