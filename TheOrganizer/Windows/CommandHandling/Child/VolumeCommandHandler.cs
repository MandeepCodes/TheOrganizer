using Core;
using NAudio.CoreAudioApi;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a Volume Command Handler that inherits from WindowBase and implements IVolumeCommandHandler.
    /// </summary>
    public class VolumeCommandHandler : WindowBase, IVolumeCommandHandler
    {
        private ILogger logger;
        private IConfig config;
        private Dictionary<string, Action<string>> StudentCommandMap = new Dictionary<string, Action<string>>();

        /// <summary>
        /// Gets the dictionary that maps student command strings to actions.
        /// </summary>
        /// <returns>A dictionary containing student commands and their corresponding actions.</returns>
        public Dictionary<string, Action<string>> GetStudentCommandMap()
        {
            return StudentCommandMap;
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
        /// Populates the student command map and initializes the logger.
        /// </summary>
        /// <returns>True if the class starts successfully, otherwise false.</returns>
        public override bool StartClass()
        {
            logger = Registrar.GetInstance<ILogger>();
            config = Registrar.GetInstance<IConfig>();
            PopulateCommands();
            return true;
        }

        /// <summary>
        /// Populates the student command map with predefined commands.
        /// </summary>
        public void PopulateCommands()
        {
            var configuration = config.GetConfig();

            StudentCommandMap.Add(configuration.Commands.ChildCommands.VolumeCommands.Up,
            (string str) =>
            {
                logger.LogAsync(LogType.DEBUG, "Increasing Volume");
                IncreaseVolume(10.0f);
            });

            StudentCommandMap.Add(configuration.Commands.ChildCommands.VolumeCommands.Down,
            (string str) =>
            {
                logger.LogAsync(LogType.DEBUG, "Decreasing Volume");
                DecreaseVolume(10.0f);
            });

            StudentCommandMap.Add(configuration.Commands.ChildCommands.VolumeCommands.Max,
            (string str) =>
            {
                logger.LogAsync(LogType.DEBUG, "Increasing Volume");
                Max();
            });

            StudentCommandMap.Add(configuration.Commands.ChildCommands.VolumeCommands.Mute,
            (string str) =>
            {
                logger.LogAsync(LogType.DEBUG, "Decreasing Volume");
                Mute();
            });
        }

        private void IncreaseVolume(float volumeChangePercentage)
        {
            MMDevice defaultDevice = GetDefaultDevice();

            float currentVolume = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;
            float newVolume = Math.Max(0.0f, Math.Min(1.0f, currentVolume + (volumeChangePercentage / 100.0f)));
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
            
            logger.LogAsync(LogType.DEBUG, $"Volume increased to {newVolume * 100}%");
        }

        private void DecreaseVolume(float volumeChangePercentage)
        {
            MMDevice defaultDevice = GetDefaultDevice();

            float currentVolume = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;
            float newVolume = Math.Max(0.0f, currentVolume - (volumeChangePercentage / 100.0f));
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;

            logger.LogAsync(LogType.DEBUG,$"Volume decreased to {newVolume * 100}%");
        }

        // Set the volume level to the maximum (1.0)
        private void Max()
        {
            var device = GetDefaultDevice();
            device.AudioEndpointVolume.Mute = false;
            device.AudioEndpointVolume.MasterVolumeLevelScalar = 1.0f;
        }

        // Mute the volume
        private void Mute()
        {
            GetDefaultDevice().AudioEndpointVolume.Mute = true;
        }

        private MMDevice GetDefaultDevice()
        {
            return new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }
    }
}