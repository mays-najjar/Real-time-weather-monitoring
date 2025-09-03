using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Bots
{
    public class SnowBot : IWeatherBot
    {
        private readonly BotConfig _config;

        public SnowBot(BotConfig config)
        {
            _config = config;
        }

        public void Update(WeatherData data)
        {
            if (!_config.Enabled) return;

            if (_config.TemperatureThreshold.HasValue && data.Temperature < _config.TemperatureThreshold.Value)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: \"{_config.Message}\"");
            }
        }        
    }
}