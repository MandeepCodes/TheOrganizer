namespace Core
{
    public class Configuration
    {
        public InternalCommunication InternalCommunication { get; set; }
    }

    public class InternalCommunication
    {
        public string? IPAddress { get; set; }
        public int Port { get; set; }
    }
}