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
        public InternalSettings InternalSettings { get; set; }

        /// <summary>
        /// Gets or sets the commands configuration.
        /// </summary>
        public Commands Commands { get; set; }

       public InternalCommands InternalCommands { get; set; }
    }

    /// <summary>
    /// Represents a collection of command settings.
    /// </summary>
    public class Commands
    {
        /// <summary>
        /// Gets or sets the master commands.
        /// </summary>
        public MasterCommands MasterCommands { get; set; }

        /// <summary>
        /// Gets or sets the child commands.
        /// </summary>
        public ChildCommands ChildCommands { get; set; }
    }

    #region Commands

    /// <summary>
    /// Represents master command settings.
    /// </summary>
    public class MasterCommands
    {
        /// <summary>
        /// Gets or sets the volume command.
        /// </summary>
        public string VolumeCommand { get; set; }
    }

    /// <summary>
    /// Represents child command settings.
    /// </summary>
    public class ChildCommands
    {
        /// <summary>
        /// Gets or sets the volume control commands.
        /// </summary>
        public VolumeCommands VolumeCommands { get; set; }
    }

    #region Child Commands

    /// <summary>
    /// Represents volume control commands.
    /// </summary>
    public class VolumeCommands
    {
        /// <summary>
        /// Gets or sets the maximum volume command.
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// Gets or sets the mute command.
        /// </summary>
        public string Mute { get; set; }

        /// <summary>
        /// Gets or sets the volume up command.
        /// </summary>
        public string Up { get; set; }

        /// <summary>
        /// Gets or sets the volume down command.
        /// </summary>
        public string Down { get; set; }
    }

    #endregion Child Commands

    #endregion Commands

    /// <summary>
    /// Represents internal communication settings, including IP address and port.
    /// </summary>
    public class InternalSettings
    {
        /// <summary>
        /// Gets or sets the IP address for internal communication.
        /// </summary>
        public string? IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the port number for internal communication.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the timeout (in seconds) for GUI visibility.
        /// </summary>
        public int GUIVisibilityTimeOutSec { get; set; }

        /// <summary>
        /// Gets or sets the timeout (in seconds) for GUI disable.
        /// </summary>
        public int GUIDisableTimeOutSec { get; set; }
    }

    public class InternalCommands
    {
        public string? ShowGUI { get; set; }

        public string? HideGUI { get; set; }
    }
}