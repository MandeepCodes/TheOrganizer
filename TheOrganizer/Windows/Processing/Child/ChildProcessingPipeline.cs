using Core;

namespace TheOrganizer
{
    /// <summary>
    /// This class represents a child processing pipeline and inherits from WindowBase and implements IChildProcessingPipeline.
    /// </summary>
    public class ChildProcessingPipeline : WindowBase, IChildProcessingPipeline
    {
        private ILogger logger;

        /// <summary>
        /// Processes a string using a child command map.
        /// </summary>
        /// <param name="str">The string to be processed.</param>
        /// <param name="childCommandMap">A dictionary that maps child commands to actions taking a string parameter.</param>
        /// <returns>True if the processing is successful, otherwise false.</returns>
        public bool Process(string str, Dictionary<string, Action<string>> childCommandMap)
        {
            try
            {
                string[] next = str.Split(' ');
                if (childCommandMap.TryGetValue(next[1], out var action))
                {
                    action.Invoke(str);
                }
            }
            catch (Exception ex)
            {
                logger.LogAsync(LogType.ERROR, ex.Message);
                return false;
            }
            return true;
        }

        #region WindowBase

        /// <summary>
        /// Overrides the RegisterClass method of the WindowBase class.
        /// For definition, check WindowBase class.
        /// </summary>
        /// <returns></returns>
        public override bool RegisterClass()
        {
            return true;
        }

        /// <summary>
        /// Overrides the StartClass method of the WindowBase class.
        /// For definition, check WindowBase class.
        /// </summary>
        /// <returns></returns>
        public override bool StartClass()
        {
            logger = Registrar.GetInstance<ILogger>();
            return true;
        }

        #endregion WindowBase
    }
}