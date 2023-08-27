using Core;

namespace TheOrganizer
{
    public class GlobalHotkey : WindowBase, IGlobalHotKey
    {
        IGUIController gUIController = null;
        static bool guiState = false;
        public override bool RegisterClass()
        {
            gUIController = Registrar.GetInstance<IGUIController>();
            return true;
        }

        public void RegisterAsync(string globalHotKey)
        {
            HotkeyManager.AddOrReplaceHotkey(
            modifierKeys: KeyModifier.Control,
            key: VirtualKey.SPACE,
            OnHotkeyPressed: OnCtrlSpacePressed, // Call the method when hotkey is pressed
            noRepeat: true);
        }

        private void OnCtrlSpacePressed(HotkeyEventArgs e)
        {
            // Replace this with your own logic
            Console.WriteLine("Ctrl+Space is pressed!");
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