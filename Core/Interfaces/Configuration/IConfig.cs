namespace Core
{
    public interface IConfig
    {
        object GetConfig(string key);

        void LoadConfigs();

        void SetConfig(string key, object value);
    }
}