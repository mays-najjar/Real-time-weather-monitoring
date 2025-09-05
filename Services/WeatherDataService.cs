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
        private readonly IWeatherDataParserFactory _parserFactory; // Use the factory
        private readonly List<IWeatherBot> _bots;

         public WeatherDataService(IWeatherDataParserFactory parserFactory, List<IWeatherBot> bots)
         {
            _parserFactory = parserFactory;
            _bots = bots;
         }
        public WeatherData ParseWeatherData(string input)
        {
            var parser = _parserFactory.GetParser(input); 
            return parser.Parse(input);
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
