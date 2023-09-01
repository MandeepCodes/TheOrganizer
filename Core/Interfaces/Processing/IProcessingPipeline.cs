namespace Core
{
    public interface IProcessingPipeline
    {
        void Ingest(string str);

        void Process(string str);


    }
}