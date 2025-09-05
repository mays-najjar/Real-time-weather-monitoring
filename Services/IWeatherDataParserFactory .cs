using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Parsers;

namespace Real_time_weather_monitoring.Services
{
    public interface IWeatherDataParserFactory 
    {
        IWeatherDataParser GetParser(string input);
    }
}