using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Bots;
using Real_time_weather_monitoring.Models;
using Real_time_weather_monitoring.Parsers;

namespace Real_time_weather_monitoring.Services
{
    public class WeatherDataService
    {
        private readonly List<IWeatherDataParser> _parsers;
        private readonly List<IWeatherBot> _bots;

        public WeatherDataService(List<IWeatherDataParser> parsers, List<IWeatherBot> bots)
        {
            _parsers = parsers;
            _bots = bots;
        }

        public WeatherData ParseWeatherData(string input)
        {
            foreach (var parser in _parsers)
            {
                if (parser.CanParse(input))
                {
                    return parser.Parse(input);
                }
            }

            throw new ArgumentException("Unsupported data format");
        }

        public void ProcessWeatherData(WeatherData data)
        {
            foreach (var bot in _bots)
            {
                bot.Update(data);
            }
        }

        public void ProcessInput(string input)
        {
            try
            {
                var weatherData = ParseWeatherData(input);
                ProcessWeatherData(weatherData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }        
    }
}