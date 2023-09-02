using Core;

namespace TheOrganizer
{
    public class Logger : WindowBase, ILogger
    {
        public void LogAsync(LogType type, string message)
        {
            Console.WriteLine(message);
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