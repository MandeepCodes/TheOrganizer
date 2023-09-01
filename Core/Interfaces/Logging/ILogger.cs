namespace Core
{
    public interface ILogger
    {
        void LogAsync(LogType type, string message);
    }
}