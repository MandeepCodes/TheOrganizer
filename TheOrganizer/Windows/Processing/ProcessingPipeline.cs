using Core;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace TheOrganizer
{
    public class ProcessingPipeline : WindowBase, IProcessingPipeline
    {
        public void Ingest(string str)
        {
            throw new NotImplementedException();
        }

        public void Process(string str)
        {
            throw new NotImplementedException();
        }

        public override bool RegisterClass()
        {
            StartServer();
            return true;
        }

        public async Task StartServer()
        {
            int port = 12345;

            UdpClient udpServer = new UdpClient(port);
            Console.WriteLine($"Server listening on port {port}");

            while (true)
            {
                UdpReceiveResult receivedResult = await udpServer.ReceiveAsync();
                string receivedMessage = Encoding.UTF8.GetString(receivedResult.Buffer);
                Console.WriteLine($"Received from {receivedResult.RemoteEndPoint}: {receivedMessage}");

                if (receivedMessage == "close chrome")
                {
                    Process[] processes = System.Diagnostics.Process.GetProcessesByName("chrome");
                    if (processes.Length > 0)
                    {
                        processes[0].CloseMainWindow();
                    }
                }

                string responseMessage = "Server received your message.";
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                await udpServer.SendAsync(responseData, responseData.Length, receivedResult.RemoteEndPoint);
            }
        }
    }
}
