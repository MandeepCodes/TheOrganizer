namespace Core
{
    /// <summary>
    /// Represents an interface for managing application configuration settings.
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Gets the current configuration settings.
        /// </summary>
        /// <returns>A <see cref="Configuration"/> object containing the current settings.</returns>
        Configuration GetConfig();

        /// <summary>
        /// Loads configuration settings from a data source (e.g., file, database).
        /// </summary>
        void LoadConfigs();

        /// <summary>
        /// Sets a specific configuration value identified by its key.
        /// </summary>
        /// <param name="key">The unique key for the configuration setting.</param>
        /// <param name="value">The value to set for the configuration setting.</param>
        void SetConfig(string key, object value);
    }
}
