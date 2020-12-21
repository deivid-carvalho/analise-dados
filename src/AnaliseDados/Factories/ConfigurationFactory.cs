using Microsoft.Extensions.Configuration;

namespace AnaliseDados.Factories
{
    public class ConfigurationFactory
    {
        private readonly string appSettingsFileName;

        public ConfigurationFactory()
        {
            appSettingsFileName = "appsettings.json";
        }

        public IConfiguration Generate()
        {
            return new ConfigurationBuilder()
                .AddJsonFile(appSettingsFileName, true, true)
                .Build();
        }
    }
}