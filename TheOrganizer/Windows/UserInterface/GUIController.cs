using Core;
using System.Diagnostics;
using System.Reflection;

namespace TheOrganizer
{
    public class GUIController : WindowBase, IGUIController
    {
        public void GlobalKeyPress(bool state)
        {
            // TODO: Change this logic when publishing app
            if (state)
            {
                // Create a relative path to WinUI.exe
                string relativePath = Path.Combine("WinUI", "bin", "Debug", "net6.0-windows", "WinUI.exe");

                // Get the base directory of the current assembly 
                string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                
                for (int i = 0; i < 4; i++)
                {
                    assemblyDirectory = Directory.GetParent(assemblyDirectory).FullName;
                }

                // Combine the base directory with the relative path to get the full path to WinUI.exe
                string winUIPath = Path.Combine(assemblyDirectory, relativePath);

                Process.Start(winUIPath);
            }
            else
            {
                Stop();
            }
        }

        public override bool RegisterClass()
        {
            return true;
        }

        public override bool StartClass()
        {
            return true;
        }

        public void Stop()
        {
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
    }
}