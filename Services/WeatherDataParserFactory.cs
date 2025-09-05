using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Parsers;

namespace Real_time_weather_monitoring.Services
{
    public class WeatherDataParserFactory : IWeatherDataParserFactory
    {
        private readonly IEnumerable<IWeatherDataParser> _availableParsers;
        
        public WeatherDataParserFactory(IEnumerable<IWeatherDataParser> availableParsers)
        {
            _availableParsers = availableParsers;
        }
        public IWeatherDataParser GetParser(string input)
        {
            foreach (var parser in _availableParsers)
            {
                if (parser.CanParse(input))
                    return parser;
            }
            throw new ArgumentException("Unsupported data format");
        } 
    }
}