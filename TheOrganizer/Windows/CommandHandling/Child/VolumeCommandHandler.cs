using Core;
using NAudio.CoreAudioApi;
using System.Data;
using System.Media;
using System.Runtime.InteropServices;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a Volume Command Handler that inherits from WindowBase and implements IVolumeCommandHandler.
    /// </summary>
    public class VolumeCommandHandler : WindowBase, IVolumeCommandHandler
    {
        private ILogger logger;
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
            PopulateCommands();
            logger = Registrar.GetInstance<ILogger>();
            return true;
        }

        /// <summary>
        /// Populates the student command map with predefined commands.
        /// </summary>
        public void PopulateCommands()
        {
            StudentCommandMap.Add("up", (string str) =>
            {
                logger.LogAsync(LogType.Debug, "Increasing Volume");
                IncreaseVolume(10.0f);
            });

            StudentCommandMap.Add("down", (string str) =>
            {
                logger.LogAsync(LogType.Debug, "Decreasing Volume");
                DecreaseVolume(10.0f);
            });

            StudentCommandMap.Add("max", (string str) =>
            {
                logger.LogAsync(LogType.Debug, "Increasing Volume");
                Max();
            });

            StudentCommandMap.Add("mute", (string str) =>
            {
                logger.LogAsync(LogType.Debug, "Decreasing Volume");
                Mute();
            });
        }

        private void IncreaseVolume(float volumeChangePercentage)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Get the current volume level
            float currentVolume = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;

            // Calculate the new volume level
            float newVolume = Math.Max(0.0f, Math.Min(1.0f, currentVolume + (volumeChangePercentage / 100.0f)));

            // Set the new volume level
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
        }

        static void DecreaseVolume(float volumeChangePercentage)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Get the current volume level
            float currentVolume = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;

            // Calculate the new volume level
            float newVolume = Math.Max(0.0f, currentVolume - (volumeChangePercentage / 100.0f));

            // Set the new volume level
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;

            Console.WriteLine($"Volume decreased to {newVolume * 100}%");
        }

        static void Max()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Set the volume level to the maximum (1.0)
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = 1.0f;
        }

        static void Mute()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Mute the volume
            defaultDevice.AudioEndpointVolume.Mute = true;
        }
    }
}