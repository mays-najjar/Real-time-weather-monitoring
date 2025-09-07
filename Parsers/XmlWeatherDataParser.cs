using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Real_time_weather_monitoring.Models;
using Real_time_weather_monitoring.Services;

namespace Real_time_weather_monitoring.Parsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(input))
                {
                    return (WeatherData?)serializer.Deserialize(reader)
                        ?? throw new ArgumentException("Invalid XML format");
                }
            }
            catch (Exception ex) when (ex is XmlException or InvalidOperationException)
            {
                throw new ArgumentException($"Failed to parse XML: {ex.Message}");
            }
        }

        public bool CanParse(string input)
        {
            return input.Trim().StartsWith('<') && input.Trim().EndsWith('>');
        }
    }
}