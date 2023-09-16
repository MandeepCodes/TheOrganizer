namespace Core
{
    /// <summary>
    /// This interface defines the contract for a student command handler.
    /// </summary>
    public interface IStudentCommandHandler
    {
        /// <summary>
        /// Gets a dictionary that maps student command strings to actions that take a string parameter.
        /// </summary>
        /// <returns>A dictionary containing student commands and their corresponding actions.</returns>
        Dictionary<string, Action<string>> GetStudentCommandMap();

        /// <summary>
        /// Populates the student command map with command-action pairs.
        /// </summary>
        void PopulateCommands();
    }
}
