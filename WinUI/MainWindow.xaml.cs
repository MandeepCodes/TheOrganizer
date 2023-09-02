using Core;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: Load this from config manager
        private string serverIP = "127.0.0.1";
        private int serverPort = 12345;
        private UdpClient udpClient;

        public MainWindow()
        {
            InitializeComponent();

            // Set window attributes
            Topmost = true; // Always on top
            ShowInTaskbar = false; // Don't show in the taskbar
            searchTextBox.Focus();
            Keyboard.Focus(searchTextBox);

            udpClient = new UdpClient(serverIP, serverPort);
            Listen();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = Width;
            double windowHeight = Height;

            Left = (screenWidth - windowWidth) / 2;
            Top = (screenHeight - windowHeight) / 3;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = searchTextBox.Text;
            byte[] messageData = Encoding.UTF8.GetBytes(query);
            udpClient.SendAsync(messageData, messageData.Length);
        }

        private async void Listen()
        {
            while (true)
            {
                var res = await udpClient.ReceiveAsync();
                if (res != null)
                {
                    var xx = Encoding.UTF8.GetString(res.Buffer);
                    if (xx == "exit")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        //TODO: Create a dropdown that shows possible action item and results
    }
}