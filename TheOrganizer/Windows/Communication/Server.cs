using Core;
using System.Net;
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
        private IPEndPoint ep;

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
                ep = receivedResult.RemoteEndPoint;
                string receivedMessage = Encoding.UTF8.GetString(receivedResult.Buffer);

                if (!string.IsNullOrEmpty(receivedMessage))
                {
                    pipeline.Ingest(receivedMessage);
                }
            }
        }

        public void StartServer()
        {
            udpServer = new UdpClient(
                config.GetConfig().InternalCommunication.Port);

            _ = StartListeningAsync();
            pipeline.GUICommand += StartSpeaking;

            logger.LogAsync(LogType.Debug, $"Server Started");
        }

        public void StartSpeaking(string newAction)
        {
            string oldMessage = "";
            if (!string.IsNullOrEmpty(newAction) && oldMessage != newAction)
            {
                string responseMessage = newAction;
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                udpServer.SendAsync(responseData, responseData.Length, ep).GetAwaiter().GetResult();
                oldMessage = newAction;
            }
        }

    }
}