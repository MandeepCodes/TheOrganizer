using Core;
using System.Diagnostics;

namespace TheOrganizer
{
    public class GUIController : WindowBase, IGUIController
    {
        public void GlobalKeyPress(bool state)
        {
            if (state)
            {
                Process.Start("C:\\Users\\ms403\\OneDrive\\Desktop\\The Organizer\\WinUI\\bin\\Debug\\net6.0-windows\\WinUI.exe");
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