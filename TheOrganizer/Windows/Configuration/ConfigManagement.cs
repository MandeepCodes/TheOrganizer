using Core;
using System.Text.Json;

namespace TheOrganizer
{
    public class ConfigManagement : WindowBase, IConfig
    {
        private static Configuration configuration;

        public object GetConfig(string key)
        {
            throw new NotImplementedException();
        }

        public void LoadConfigs()
        {
            var text = File.ReadAllText("Windows\\settings.json");
            configuration = JsonSerializer.Deserialize<Configuration>(text);
        }

        public override bool RegisterClass()
        {
            LoadConfigs();
            return true;
        }

        public void SetConfig(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}