namespace Core
{
    /// <summary>
    /// Base Abstract Class to drive Factory Mechanism
    /// </summary>
    public abstract class CoreBase
    {
        /// <summary>
        /// Register with main service
        /// </summary>
        /// <returns></returns>
        public abstract bool RegisterClass();

        /// <summary>
        /// load necessary dependencies
        /// </summary>
        /// <returns></returns>
        public abstract bool StartClass();

        /// <summary>
        /// Systematically dispose the objects
        /// </summary>
        /// <returns></returns>
        //public abstract bool UnregisterClass();
    }

    public abstract class WindowBase : CoreBase
    {
    }

    public abstract class LinuxBase : CoreBase
    {
    }
}