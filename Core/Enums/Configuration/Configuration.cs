namespace Core
{
    /// <summary>
    /// Represents a configuration object containing various settings.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Gets or sets the internal communication settings.
        /// </summary>
        public InternalCommunication InternalCommunication { get; set; }
    }

    /// <summary>
    /// Represents internal communication settings, including IP address and port.
    /// </summary>
    public class InternalCommunication
    {
        /// <summary>
        /// Gets or sets the IP address for internal communication.
        /// </summary>
        public string? IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the port number for internal communication.
        /// </summary>
        public int Port { get; set; }
    }
}
