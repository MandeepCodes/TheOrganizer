using Core;

namespace TheOrganizer
{
    public class GlobalHotkey : WindowBase, IGlobalHotKey
    {
        private IGUIController gUIController = null;
        private static bool guiState = false;
        private ILogger logger = null;

        public override bool RegisterClass()
        {
            return true;
        }

        public override bool StartClass()
        {
            gUIController = Registrar.GetInstance<IGUIController>();
            logger = Registrar.GetInstance<ILogger>();
            return true;
        }

        public void RegisterAsync(string globalHotKey)
        {
            HotkeyManager.AddOrReplaceHotkey(
            modifierKeys: KeyModifier.Control,
            key: VirtualKey.SPACE,
            OnHotkeyPressed: OnCtrlSpacePressed,
            noRepeat: true);
        }

        private void OnCtrlSpacePressed(HotkeyEventArgs e)
        {
            // Replace this with your own logic
            logger.LogAsync(LogType.Debug, "Ctrl+Space is pressed!");
            if (!guiState)
            {
                guiState = true;
                gUIController.GlobalKeyPress(true);
            }
            else
            {
                guiState = false;
                gUIController.GlobalKeyPress(false);
            }
        }

        public void UnregisterAsync(string globalHotKey)
        {
            throw new NotImplementedException();
        }
    }
}