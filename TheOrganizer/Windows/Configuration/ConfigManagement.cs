using Core;
using System.Text.Json;

namespace TheOrganizer
{
    /// <summary>
    /// Represents a class for managing application configuration settings.
    /// </summary>
    public class ConfigManagement : WindowBase, IConfig
    {
        private static Configuration Configuration;

        /// <summary>
        /// Retrieves the current application configuration.
        /// </summary>
        /// <returns>The <see cref="Configuration"/> object representing the application's configuration.</returns>
        public Configuration GetConfig()
        {
            return Configuration;
        }

        /// <summary>
        /// Loads configuration settings from a JSON file.
        /// </summary>
        public void LoadConfigs()
        {
            var text = File.ReadAllText("Windows\\settings.json");
            Configuration = JsonSerializer.Deserialize<Configuration>(text);
        }

        public override bool RegisterClass()
        {
            // Load configuration settings when registering the class (implementation specific).
            LoadConfigs();
            return true;
        }

        /// <summary>
        /// Sets a specific configuration value identified by its key (not implemented).
        /// </summary>
        /// <param name="key">The unique key for the configuration setting.</param>
        /// <param name="value">The value to set for the configuration setting.</param>
        public void SetConfig(string key, object value)
        {
            throw new NotImplementedException();
        }

        public override bool StartClass()
        {
            // Start the class (implementation specific).
            return true;
        }
    }
}
