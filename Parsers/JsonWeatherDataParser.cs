using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Real_time_weather_monitoring.Parsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                return JsonSerializer.Deserialize<WeatherData>(input) 
                    ?? throw new ArgumentException("Invalid JSON format");
            }
            catch (JsonException ex)
            {
                throw new ArgumentException($"Failed to parse JSON: {ex.Message}");
            }
        }

        public bool CanParse(string input)
        {
            return input.Trim().StartsWith('{') && input.Trim().EndsWith('}');
        }         
    }
}