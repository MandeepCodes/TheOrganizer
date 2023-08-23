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
            throw new NotImplementedException();
        }

        public void UnregisterAsync(string globalHotKey)
        {
            throw new NotImplementedException();
        }
    }
}