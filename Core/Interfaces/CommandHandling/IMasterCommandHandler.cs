namespace Core
{
    /// <summary>
    /// This interface defines the contract for a master command handler.
    /// </summary>
    public interface IMasterCommandHandler
    {
        /// <summary>
        /// Gets a dictionary that maps master command strings to actions that take a string parameter.
        /// </summary>
        /// <returns>A dictionary containing master commands and their corresponding actions.</returns>
        Dictionary<string, Action<string>> GetMasterCommandMap();

        /// <summary>
        /// Populates the master command map with command-action pairs.
        /// </summary>
        void PopulateCommands();
    }
}
