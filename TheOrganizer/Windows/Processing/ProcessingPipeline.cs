using Core;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a Processing Pipeline that inherits from WindowBase and implements IProcessingPipeline.
    /// </summary>
    public class ProcessingPipeline : WindowBase, IProcessingPipeline
    {
        #region Varibles
        private ILogger logger;
        public event GUICommandEventHandler GUICommand;
        private IMasterCommandHandler masterCommandHandler;
        #endregion

        #region Core Base

        /// <summary>
        /// Overrides the RegisterClass method from the WindowBase class.
        /// </summary>
        /// <returns>True if registration is successful, otherwise false.</returns>
        public override bool RegisterClass()
        {
            return true;
        }

        /// <summary>
        /// Overrides the StartClass method from the WindowBase class.
        /// Initializes the logger and masterCommandHandler.
        /// </summary>
        /// <returns>True if the class starts successfully, otherwise false.</returns>
        public override bool StartClass()
        {
            logger = Registrar.GetInstance<ILogger>();
            masterCommandHandler = Registrar.GetInstance<IMasterCommandHandler>();
            return true;
        }

        #endregion Core Base

        /// <summary>
        /// Ingests a string and processes it.
        /// </summary>
        /// <param name="str">The string to ingest and process.</param>
        public void Ingest(string str)
        {
            logger.LogAsync(LogType.Debug, $"Received input: {str}");
            Process(str.ToLower());
        }

        /// <summary>
        /// Processes a string by invoking the corresponding action based on the master command map.
        /// </summary>
        /// <param name="str">The string to process.</param>
        public void Process(string str)
        {
            var newCommands = masterCommandHandler.GetMasterCommandMap();
            string data = str.Split(' ')[0];

            if (newCommands.TryGetValue(data, out var action))
            {
                action.Invoke(str);
            }
            else
            {
                logger.LogAsync(LogType.Debug, "No associated command with : " + str);
            }
        }
    }
}
