namespace Core
{
    /// <summary>
    /// Represents an interface for managing server operations.
    /// </summary>
    public interface IServer
    {
        /// <summary>
        /// Starts the server.
        /// </summary>
        void StartServer();

        /// <summary>
        /// Starts listening for incoming connections asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task StartListeningAsync();

        /// <summary>
        /// Starts speaking or communicating with the server.
        /// </summary>
        /// <param name="newAction">The action or message to send to the server.</param>
        void StartSpeaking(string newAction);
    }
}
