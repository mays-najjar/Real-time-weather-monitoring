using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Parsers
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string input);
        bool CanParse(string input);
    }
}