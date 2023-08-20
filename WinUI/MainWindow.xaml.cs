using System.Diagnostics;
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
        public MainWindow()
        {
            InitializeComponent();

            // Set window attributes
            Topmost = true; // Always on top
            ShowInTaskbar = false; // Don't show in the taskbar

            Thread t = new Thread(KeyPress);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void KeyPress()
        {
            while (true)
            {
                Thread.Sleep(100);

                bool isCtrlPressed = (Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > 0;
                bool isSpacePressed = (Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0;

                Dispatcher.Invoke(() =>
                {
                    if (isCtrlPressed && isSpacePressed)
                    {
                        // Toggle UI visibility
                        ToggleUIVisibility();
                    }
                });
            }
        }

        private bool uiVisible = true;

        private void ToggleUIVisibility()
        {
            uiVisible = !uiVisible;

            // Update UI elements' visibility based on the state
            searchTextBox.Visibility = uiVisible ? Visibility.Visible : Visibility.Collapsed;
            // Toggle visibility of other UI elements similarly

            if (uiVisible)
            {
                // Set focus to the searchTextBox when making it visible
                searchTextBox.Focus();
                Keyboard.Focus(searchTextBox);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Center the window on the screen
            CenterWindowOnScreen();
        }

        private void CenterWindowOnScreen()
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

            if (query == "spotify")
            {
                string a = @"C:\Users\ms403\AppData\Local\Microsoft\WindowsApps\Spotify.exe";
                Process.Start(a);
            }

            // Implement your live search logic here based on the entered query
            Title = query;
        }
    }
}