using Core;
using System.Text.Json;

namespace TheOrganizer
{
    public class ConfigManagement : WindowBase, IConfig
    {
        private static Configuration Configuration;

        public Configuration GetConfig()
        {
            return Configuration;
        }

        public void LoadConfigs()
        {
            var text = File.ReadAllText("Windows\\settings.json");
            Configuration = JsonSerializer.Deserialize<Configuration>(text);
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

        public override bool StartClass()
        {
            return true;
        }
    }
}