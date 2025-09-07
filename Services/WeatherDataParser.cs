using System;
using Real_time_weather_monitoring.Models;
using Real_time_weather_monitoring.Parsers;


namespace Real_time_weather_monitoring.Services
{
  public class WeatherDataParser : IWeatherDataParser
    {
        private IWeatherDataParser? _crurrentParser;

        public void SetParser(IWeatherDataParser parser)
        {
            _crurrentParser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public WeatherData Parse(string input)
        {
            if (_crurrentParser == null)
                throw new InvalidOperationException("Parser not set. Please set a parser before parsing data.");
            return _crurrentParser.Parse(input);
        }
        
        public bool CanParse(string input)
        {
            if (_crurrentParser == null)
                throw new InvalidOperationException("Parser not set. Please set a parser before checking capability.");
            return _crurrentParser.CanParse(input);
        }
    }
}