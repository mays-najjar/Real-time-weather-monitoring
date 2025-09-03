using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring.Models
{
    public class WeatherData
    {
        public string Location { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public double Humidity { get; set; }        
    }
}