using Core;
using System.Net.Sockets;
using System.Text;

namespace TheOrganizer
{
    public class Server : WindowBase, IServer
    {
        private ILogger logger;
        private IConfig config;
        private UdpClient udpServer;
        private IProcessingPipeline pipeline;

        #region Window Base

        public override bool RegisterClass()
        {
            return true;
        }

        public override bool StartClass()
        {
            logger = Registrar.GetInstance<ILogger>();
            config = Registrar.GetInstance<IConfig>();
            pipeline = Registrar.GetInstance<IProcessingPipeline>();
            StartServer();
            return true;
        }

        #endregion Window Base
        public async Task StartListeningAsync()
        {
            while (true)
            {
                UdpReceiveResult receivedResult = await udpServer.ReceiveAsync();
                string receivedMessage = Encoding.UTF8.GetString(receivedResult.Buffer);
                logger.LogAsync(LogType.Debug, $"Received : {receivedMessage}");

                if (!string.IsNullOrEmpty(receivedMessage))
                {
                    pipeline.Ingest(receivedMessage);
                }
            }
        }

        public void StartServer()
        {
            udpServer = new UdpClient(config.GetConfig().InternalCommunication.Port);
            logger.LogAsync(LogType.Debug, $"Server Started");
            _ = StartListeningAsync();
        }

        public async Task StartSpeakingAsync()
        {
            string responseMessage = "a";
            byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
            await udpServer.SendAsync(responseData, responseData.Length);
        }

        
    }
}