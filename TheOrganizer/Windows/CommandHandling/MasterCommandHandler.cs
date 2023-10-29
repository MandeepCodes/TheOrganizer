using Core;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a Master Command Handler that inherits from WindowBase and implements IMasterCommandHandler.
    /// </summary>
    public class MasterCommandHandler : WindowBase, IMasterCommandHandler
    {
        private ILogger logger;
        private Dictionary<string, Action<string>> MasterCommandMap = new Dictionary<string, Action<string>>();
        private IChildProcessingPipeline pipeline;
        private IConfig config;

        /// <summary>
        /// Populates the master command map with predefined commands.
        /// </summary>
        public void PopulateCommands()
        {
            var configuration = config.GetConfig();

            MasterCommandMap.Add(configuration.Commands.MasterCommands.VolumeCommand,
            (string str) =>
            {
                logger.LogAsync(LogType.DEBUG, "Sending data to Volume processing pipline");
                var volumeCommandMap = Registrar.GetInstance<IVolumeCommandHandler>().GetStudentCommandMap();
                pipeline.Process(str, volumeCommandMap);
            });
        }

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
        /// Initializes the logger, pipeline, and populates the master command map.
        /// </summary>
        /// <returns>True if the class starts successfully, otherwise false.</returns>
        public override bool StartClass()
        {
            logger = Registrar.GetInstance<ILogger>();
            pipeline = Registrar.GetInstance<IChildProcessingPipeline>();
            config = Registrar.GetInstance<IConfig>();  
            PopulateCommands();
            return true;
        }

        /// <summary>
        /// Gets the dictionary that maps master command strings to actions.
        /// </summary>
        /// <returns>A dictionary containing master commands and their corresponding actions.</returns>
        public Dictionary<string, Action<string>> GetMasterCommandMap()
        {
            return MasterCommandMap;
        }
    }
}