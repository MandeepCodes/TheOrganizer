namespace Core
{
    public interface IServer
    {
        void StartServer();

        Task StartListeningAsync();

        Task StartSpeakingAsync();
    }
}