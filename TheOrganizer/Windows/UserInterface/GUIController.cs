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
                Process.Start("C:\\Users\\Mandeep_S\\OneDrive - Dell Technologies\\Desktop\\TheOrganizer\\WinUI\\bin\\Debug\\net6.0-windows\\WinUI.exe");
            }
            else
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

        public override bool RegisterClass()
        {
            return true;
        }
    }
}