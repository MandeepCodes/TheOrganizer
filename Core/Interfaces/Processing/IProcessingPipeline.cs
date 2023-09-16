namespace Core
{
    /// <summary>
    /// Represents a delegate used to raise information about actions to be performed.
    /// </summary>
    /// <param name="newAction">A string describing the new action to be executed.</param>
    public delegate void GUICommandEventHandler(string newAction);

    /// <summary>
    /// Defines an interface for a processing pipeline that can ingest and process strings.
    /// </summary>
    public interface IProcessingPipeline
    {
        /// <summary>
        /// Event triggered when a GUI command is received.
        /// </summary>
        event GUICommandEventHandler GUICommand;

        /// <summary>
        /// Ingests a string into the processing pipeline.
        /// </summary>
        /// <param name="str">The string to be ingested.</param>
        void Ingest(string str);

        /// <summary>
        /// Processes a string within the pipeline.
        /// </summary>
        /// <param name="str">The string to be processed.</param>
        void Process(string str);
    }
}
