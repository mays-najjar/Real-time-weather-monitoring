using Real_time_weather_monitoring.Bots;
using Real_time_weather_monitoring.Parsers;
using Real_time_weather_monitoring.Services;
namespace Real_time_weather_monitoring.Services
{
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var configService = new ConfigurationService();
            var config = configService.LoadConfiguration("config.json");

            var parsers = new List<IWeatherDataParser>
                {
                    new JsonWeatherDataParser(),
                    new XmlWeatherDataParser()
                };

            var bots = new List<IWeatherBot>
                {
                    new RainBot(config.RainBot),
                    new SunBot(config.SunBot),
                    new SnowBot(config.SnowBot)
                };

            var weatherService = new WeatherDataService(parsers, bots);

            Console.WriteLine("Weather Monitoring System Started!");
            Console.WriteLine("Enter weather data (JSON or XML format) or type 'exit' to quit:");

            while (true)
            {
                Console.Write("\nEnter weather data: ");
                var input = Console.ReadLine();

                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter valid weather data.");
                    continue;
                }

                weatherService.ProcessInput(input);
            }

            Console.WriteLine("Weather Monitoring System Stopped.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
}
