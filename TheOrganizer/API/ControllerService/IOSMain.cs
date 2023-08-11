namespace TheOrganizer
{
    /// <summary>
    /// Interface Operating System Main
    /// </summary>
    public interface IOSMain
    {
        /// <summary>
        /// Load necessary dependencies
        /// </summary>
        void PreStart();

        /// <summary>
        /// Start the service
        /// </summary>
        void Start();

        /// <summary>
        /// Stop properly
        /// </summary>
        void Stop();
    }
}