using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

            try
            {
                var json = File.ReadAllText(configPath);
                return JsonSerializer.Deserialize<BotConfiguration>(json) 
                    ?? throw new InvalidOperationException("Failed to deserialize configuration");
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Invalid configuration format: {ex.Message}");
            }
        }        
    }
}