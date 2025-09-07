using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Bots
{
    public class SnowBot : BotBase, IWeatherBot
    {

        public SnowBot(BotConfig config) : base(config) { }
        protected override string BotName => "SnowBot";
        public void Update(WeatherData data)
        {
            if (!_config.Enabled) return;

            if (_config.TemperatureThreshold.HasValue && data.Temperature < _config.TemperatureThreshold.Value)
            {
                PrintActivation();
            }
        }
    }
}