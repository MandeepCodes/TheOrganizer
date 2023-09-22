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

        public Commands Commands { get; set; }
    }

    public class Commands
    {
        public MasterCommands MasterCommands { get; set; }

        public ChildCommands ChildCommands { get; set; }
    }

    #region Commands
    public class MasterCommands
    {
        public string VolumeCommand { get; set; }
    }

    public class ChildCommands
    {
        public VolumeCommands VolumeCommands { get; set; }
    }

    #region Child Commands
    public class VolumeCommands
    {
        public string Max { get; set; }
        public string Mute { get; set; }
        public string Up { get; set; }
        public string Down { get; set; }

    }
    #endregion

    #endregion
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
