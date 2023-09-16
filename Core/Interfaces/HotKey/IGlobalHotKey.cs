namespace Core
{
    /// <summary>
    /// Represents an interface for managing global hotkeys.
    /// </summary>
    public interface IGlobalHotKey
    {
        /// <summary>
        /// Registers a global hotkey asynchronously.
        /// </summary>
        /// <param name="globalHotKey">The string representation of the hotkey to register.</param>
        void RegisterAsync(string globalHotKey);

        /// <summary>
        /// De-registers a global hotkey asynchronously.
        /// </summary>
        /// <param name="globalHotKey">The string representation of the hotkey to de-register.</param>
        void UnregisterAsync(string globalHotKey);
    }
}
