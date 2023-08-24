using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOrganizer
{
    public class HotkeyEventArgs : EventArgs
    {
        public KeyModifier ModifierKeys { get; }
        public VirtualKey Key { get; }
        public ushort Id { get; }
        public uint Time { get; }

        public HotkeyEventArgs(KeyModifier modifierKeys, VirtualKey key, ushort id, uint time)
        {
            ModifierKeys = modifierKeys;
            Key = key;
            Id = id;
            Time = time;
        }
    }
}
