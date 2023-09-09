using Core;

namespace TheOrganizer
{
    public class ProcessingPipeline : WindowBase, IProcessingPipeline
    {
        private ILogger logger;

        public event GUICommandEventHandler GUICommand;

        #region Core Base

        public override bool RegisterClass()
        {
            return true;
        }

        public override bool StartClass()
        {
            logger = Registrar.GetInstance<ILogger>();
            return true;
        }

        #endregion Core Base

        public void Ingest(string str)
        {
            logger.LogAsync(LogType.Debug, $"Received : {str}");
            Process(str.ToLower());
        }

        public void Process(string str)
        {
            if (Enum.TryParse<MasterKeys>(str, out MasterKeys key))
            {
                switch (key)
                {
                    case MasterKeys.volume:
                        logger.LogAsync(LogType.Debug, "vol pipe");
                        GUICommand?.Invoke(str);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}