using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Bots
{
    public abstract class BotBase
    {
        protected readonly BotConfig _config;

        protected BotBase(BotConfig config)
        {
            _config = config;
        }

         protected abstract string BotName { get; }
        protected void PrintActivation()
        {
            Console.WriteLine($"{BotName} activated!");
            Console.WriteLine($"{BotName}: \"{_config.Message}\"");
        }
    }
}