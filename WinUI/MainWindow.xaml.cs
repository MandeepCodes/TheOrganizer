using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;

namespace WinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set window attributes
            Topmost = true; // Always on top
            ShowInTaskbar = false; // Don't show in the taskbar
            searchTextBox.Focus();
            Keyboard.Focus(searchTextBox);
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
            string serverIP = "127.0.0.1";
            int serverPort = 12345;

            UdpClient udpClient = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

            string query = searchTextBox.Text;

            byte[] messageData = Encoding.UTF8.GetBytes(query);
            udpClient.SendAsync(messageData, messageData.Length, serverEndPoint);

            if (query == "spotify")
            {
                string a = @"C:\Users\ms403\AppData\Local\Microsoft\WindowsApps\Spotify.exe";
                Process.Start(a);
            }
            else if (query == "exit")
            {
                Environment.Exit(0);
            }

            // Implement your live search logic here based on the entered query
            Title = query;
        }
    }
}