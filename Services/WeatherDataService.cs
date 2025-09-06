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
        private readonly IWeatherDataParser _parser; 
        private readonly List<IWeatherBot> _bots;

         public WeatherDataService(IWeatherDataParser parser, List<IWeatherBot> bots)
         {
            _parser = parser;
            _bots = bots;
         }
         public WeatherData ParseWeatherData(string input)
        {
            return _parser.Parse(input);
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
