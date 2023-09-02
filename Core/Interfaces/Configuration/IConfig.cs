namespace Core
{
    public interface IConfig
    {
        Configuration GetConfig();

        void LoadConfigs();

        void SetConfig(string key, object value);
    }
}