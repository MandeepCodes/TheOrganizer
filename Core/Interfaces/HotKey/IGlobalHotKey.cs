namespace Core
{
    public interface IGlobalHotKey
    {
        /// <summary>
        /// Registers the global hotkey
        /// </summary>
        /// <param name="globalHotKey"></param>
        void RegisterAsync(string globalHotKey);

        /// <summary>
        /// De-Register the global hotKey
        /// </summary>
        /// <param name="globalHotKey"></param>
        void UnregisterAsync(string globalHotKey);
    }
}