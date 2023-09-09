namespace Core
{
    public interface IServer
    {
        void StartServer();

        Task StartListeningAsync();

        void StartSpeaking(string newAction);
    }
}