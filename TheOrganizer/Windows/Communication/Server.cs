using Core;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a server that listens for incoming messages and processes them.
    /// </summary>
    public class Server : WindowBase, IServer
    {
        private ILogger logger;
        private IConfig config;
        private UdpClient udpServer;
        private IProcessingPipeline pipeline;
        private IPEndPoint ep;
        private string oldAction = string.Empty;

        #region Window Base

        public override bool RegisterClass()
        {
            // Register the class (implementation specific).
            return true;
        }

        public override bool StartClass()
        {
            // Initialize dependencies, start the server, and return success (implementation specific).
            logger = Registrar.GetInstance<ILogger>();
            config = Registrar.GetInstance<IConfig>();
            pipeline = Registrar.GetInstance<IProcessingPipeline>();
            StartServer();
            return true;
        }

        #endregion Window Base

        /// <summary>
        /// Asynchronously starts listening for incoming messages.
        /// </summary>
        public async Task StartListeningAsync()
        {
            try
            {
                while (true)
                {
                    UdpReceiveResult receivedResult = await udpServer.ReceiveAsync();
                    ep = receivedResult.RemoteEndPoint;
                    string receivedMessage = Encoding.UTF8.GetString(receivedResult.Buffer);

                    if (!string.IsNullOrEmpty(receivedMessage))
                    {
                        // Ingest the received message into the processing pipeline.
                        pipeline.Ingest(receivedMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogAsync(LogType.Error, $"Error in StartListeningAsync: {ex.Message}");
            }
        }

        /// <summary>
        /// Starts the UDP server.
        /// </summary>
        public void StartServer()
        {
            try
            {
                udpServer = new UdpClient(config.GetConfig().InternalCommunication.Port);
                _ = StartListeningAsync(); // Start listening asynchronously.
                pipeline.GUICommand += StartSpeaking; // Subscribe to GUICommand event.
                logger.LogAsync(LogType.Debug, "Server Started");
            }
            catch (Exception ex)
            {
                logger.LogAsync(LogType.Error, $"Error starting server: {ex.Message}");
            }
        }

        /// <summary>
        /// Sends a response message to the client.
        /// </summary>
        /// <param name="newAction">The action to send as a response.</param>
        public void StartSpeaking(string newAction)
        {
            if (!string.IsNullOrEmpty(newAction) && oldAction != newAction)
            {
                try
                {
                    string responseMessage = newAction;
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                    udpServer.SendAsync(responseData, responseData.Length, ep).GetAwaiter().GetResult();
                    oldAction = newAction;
                }
                catch (Exception ex)
                {
                    logger.LogAsync(LogType.Error, $"Error in StartSpeaking: {ex.Message}");
                }
            }
        }
    }
}
