using Core;

namespace TheOrganizer
{
    public class GlobalHotkey : WindowBase, IGlobalHotKey
    {
        public override bool RegisterClass()
        {
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

        private static void OnCtrlSpacePressed(HotkeyEventArgs e)
        {
            // Replace this with your own logic
            Console.WriteLine("Ctrl+Space is pressed!");
        }

        public void UnregisterAsync(string globalHotKey)
        {
            throw new NotImplementedException();
        }
    }
}