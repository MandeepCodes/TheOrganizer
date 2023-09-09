namespace Core
{
    /// <summary>
    /// Delegate to raise info when action is to be made
    /// </summary>
    /// <param name="newAction"></param>
    public delegate void GUICommandEventHandler(string newAction);

    public interface IProcessingPipeline
    {
        event GUICommandEventHandler GUICommand;
        void Ingest(string str);

        void Process(string str);
    }
}