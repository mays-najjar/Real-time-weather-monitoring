using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring.Models
{
    public class BotConfiguration
    {
        public BotConfig RainBot { get; set; } = new BotConfig();
        public BotConfig SunBot { get; set; } = new BotConfig();
        public BotConfig SnowBot { get; set; } = new BotConfig();
    }        
}