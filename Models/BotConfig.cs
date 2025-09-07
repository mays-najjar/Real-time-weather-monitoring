using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring.Models
{
    public class BotConfig
    {
        public bool Enabled { get; set; }
        public double? TemperatureThreshold { get; set; }
        public double? HumidityThreshold { get; set; }
        public string Message { get; set; } = string.Empty;  
    }
}