using Core;

namespace TheOrganizer
{
    public class ProcessingPipeline : WindowBase, IProcessingPipeline
    {
        #region Core Base

        public override bool RegisterClass()
        {
            return true;
        }

        public override bool StartClass()
        {
            return true;
        }

        #endregion Core Base

        public void Ingest(string str)
        {
            //throw new NotImplementedException();
        }

        public void Process(string str)
        {
            throw new NotImplementedException();
        }
    }
}