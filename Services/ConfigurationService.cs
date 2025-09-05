
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Services
{
    public class ConfigurationService
    {
        public BotConfiguration LoadConfiguration(string configPath)
        {
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configPath}");
            }
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(configPath) ?? Directory.GetCurrentDirectory())
                .AddJsonFile(Path.GetFileName(configPath), optional: false, reloadOnChange: false)
                .Build();

            var botConfig = configuration.Get<BotConfiguration>();
            if (botConfig == null)
            {
                throw new InvalidOperationException("Failed to bind configuration to BotConfiguration object");
            }
            return botConfig;
        }
    }
}