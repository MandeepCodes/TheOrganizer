namespace Core
{
    // This interface defines the contract for a child processing pipeline.
    public interface IChildProcessingPipeline
    {
        /// <summary>
        /// Processes a string with a given child command map.
        /// </summary>
        /// <param name="str">The string to be processed.</param>
        /// <param name="childCommandMap">A dictionary that maps command strings to actions.</param>
        /// <returns>True if the processing is successful, otherwise false.</returns>
        bool Process(string str, Dictionary<string, Action<string>> childCommandMap);
    }
}
