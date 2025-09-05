using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Bots;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Services
{
    public class BotFactory : IBotFactory
    {
        public List<IWeatherBot> CreateBots(BotConfiguration config)
        {
            var bots = new List<IWeatherBot>();
            if (config.RainBot != null)
            {
                bots.Add(new RainBot(config.RainBot));
            }
            if (config.SunBot != null)
            {
                bots.Add(new SunBot(config.SunBot));
            }
            if (config.SnowBot != null)
            {
                bots.Add(new SnowBot(config.SnowBot));
            }
            return bots;
        }
    }
}
