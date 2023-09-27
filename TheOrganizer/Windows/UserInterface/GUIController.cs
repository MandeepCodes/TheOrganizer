using Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TheOrganizer
{
    /// <summary>
    /// Represents the GUI controller for managing UI visibility and interaction.
    /// </summary>
    public class GUIController : WindowBase, IGUIController
    {
        #region Variables

        private string winUIPath = string.Empty;
        private bool GUIEnabled = false;
        private bool GUIVisible = false;
        private int timerToStop;
        private int timerToHide;
        private Timer? stopTimer;
        private Timer? hideTimer;

        private string? showGUICommand;
        private string? hideGUICommand;

        #endregion Variables

        #region Interface Variables

        private IServer server;
        private IConfig config;

        #endregion Interface Variables

        /// <summary>
        /// Handles global key presses and toggles UI visibility.
        /// </summary>
        public void GlobalKeyPress()
        {
            if (GUIEnabled)
            {
                if (GUIVisible)
                {
                    // Hide the UI if it's currently visible.
                    HideUI(null);

                    // Start the timer to stop the UI.
                    InitiateStopTimer();
                }
                else
                {
                    // Show the UI if it's currently hidden.
                    ShowUI();

                    // Start the timer to hide .
                    InitaiteHideTimer();

                    // Start the timer to stop the UI.
                    InitiateStopTimer();
                }
            }
            else
            {
                // Start the UI if it's currently not enabled.
                StartUI();

                // Start the timer to hide .
                InitaiteHideTimer();

                // Start the timer to stop the UI.
                InitiateStopTimer();
            }
        }

        /// <summary>
        /// Initializes or resets the timer to stop the UI.
        /// </summary>
        private void InitiateStopTimer()
        {
            if (stopTimer == null)
            {
                // Create a timer to stop the UI.
                stopTimer = new Timer(StopUI, null, TimeSpan.FromSeconds(timerToStop), Timeout.InfiniteTimeSpan);
            }
            else
            {
                // Reset the existing timer to stop the UI.
                stopTimer.Change(TimeSpan.FromSeconds(timerToStop), Timeout.InfiniteTimeSpan);
            }
        }

        /// <summary>
        /// Initializes or resets the timer to hide the UI.
        /// </summary>
        private void InitaiteHideTimer()
        {
            if (hideTimer == null)
            {
                // Create a timer to hide the UI.
                hideTimer = new Timer(HideUI, null, TimeSpan.FromSeconds(timerToHide), Timeout.InfiniteTimeSpan);
            }
            else
            {
                // Reset the existing timer to hide the UI.
                hideTimer.Change(TimeSpan.FromSeconds(timerToHide), Timeout.InfiniteTimeSpan);
            }
        }

        /// <summary>
        /// Shows the UI and sends a message to start it.
        /// </summary>
        private void ShowUI()
        {
            // Send a message to show the UI.
            server.StartSpeaking(showGUICommand);
            GUIVisible = true;
        }

        /// <summary>
        /// Sends a message to hide the UI.
        /// </summary>
        private void HideUI(object? state)
        {
            // Send a message to hide the UI.
            server.StartSpeaking(hideGUICommand);
            GUIVisible = false;
        }

        /// <summary>
        /// Stops the UI and terminates associated processes.
        /// </summary>
        private void StopUI(object? state)
        {
            // Stop the UI and disable it.
            GUIVisible = false;
            GUIEnabled = false;

            // Find and terminate any processes named "WinUI".
            var process = Process.GetProcessesByName("WinUI");
            foreach (var pro in process)
            {
                try
                {
                    pro.Kill(true);
                }
                catch { }
            }
        }

        /// <summary>
        /// Starts the UI application and enables it.
        /// </summary>
        private void StartUI()
        {
            // Start the UI, enabling it.
            GUIVisible = true;
            GUIEnabled = true;

            // Launch the WinUI application.
            Process.Start(winUIPath);
        }

        #region Windows Base

        public override bool RegisterClass()
        {
            return true;
        }

        public override bool StartClass()
        {
            // Initialize server and configuration.
            server = Registrar.GetInstance<IServer>();
            config = Registrar.GetInstance<IConfig>();
            timerToHide = config.GetConfig().InternalSettings.GUIVisibilityTimeOutSec;
            timerToStop = config.GetConfig().InternalSettings.GUIDisableTimeOutSec;
            showGUICommand = config.GetConfig().InternalCommands.ShowGUI;
            hideGUICommand = config.GetConfig().InternalCommands.HideGUI;

#if DEBUG
            try
            {
                // TODO: Change this logic when publishing app
                // Create a relative path to WinUI.exe
                string relativePath = Path.Combine("WinUI", "bin", "Debug", "net6.0-windows", "WinUI.exe");

                // Get the base directory of the current assembly
                string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                for (int i = 0; i < 4; i++)
                {
                    assemblyDirectory = Directory.GetParent(assemblyDirectory).FullName;
                }

                // Combine the base directory with the relative path to get the full path to WinUI.exe
                winUIPath = Path.Combine(assemblyDirectory, relativePath);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
#endif
        }

        #endregion Windows Base
    }
}
