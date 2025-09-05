using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Bots
{
    public class RainBot : BotBase, IWeatherBot
    {
      private readonly BotConfig _config;

        public RainBot(BotConfig config)
        {
            _config = config;
        }

        public void Update(WeatherData data)
        {
            if (!_config.Enabled) return;

            if (_config.HumidityThreshold.HasValue && data.Humidity > _config.HumidityThreshold.Value)
            {
                PrintActivation("RainBot", _config.Message);
            }
        }        
    }
}