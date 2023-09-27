namespace Core
{
    /// <summary>
    /// Represents an interface for controlling the graphical user interface (GUI).
    /// </summary>
    public interface IGUIController
    {
        /// <summary>
        /// Handles global key presses or releases.
        /// </summary>
        /// <param name="state">True for key press, false for key release.</param>
        void GlobalKeyPress();
    }
}
