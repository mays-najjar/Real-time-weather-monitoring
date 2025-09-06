using Real_time_weather_monitoring.Bots;
using Real_time_weather_monitoring.Parsers;
using Real_time_weather_monitoring.Services;

namespace Real_time_weather_monitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUI();
            try
            {
                var configService = new ConfigurationService();
                var configPath = Path.GetFullPath("appsettings.json");
                var config = configService.LoadConfiguration(configPath);
                IBotFactory botFactory = new BotFactory();
                var bots = botFactory.CreateBots(config);
                var weatherParser = new WeatherDataParser();
                var weatherService = new WeatherDataService(weatherParser, bots);

                ui.ShowWelcome();

                var parsers = new List<IWeatherDataParser>
                {
                    new JsonWeatherDataParser(),
                    new XmlWeatherDataParser()
                };

                while (true)
                {
                    var input = ui.ReadInput();

                    if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        ui.ShowMessage("Please enter valid weather data.");
                        continue;
                    }

                    var parser = parsers.FirstOrDefault(p => p.CanParse(input));
                    if (parser != null)
                    {
                        weatherParser.SetParser(parser);
                    }
                    else
                    {
                        ui.ShowMessage("Unsupported data format. Please enter JSON or XML.");
                        continue;
                    }

                    try
                    {
                        weatherService.ProcessInput(input);
                    }
                    catch (Exception ex)
                    {
                        ui.ShowError($"Error: {ex.Message}");
                    }
                }

                ui.ShowMessage("Weather Monitoring System Stopped.");
            }
            catch (Exception ex)
            {
                ui.ShowError($"Fatal error: {ex.Message}");
                ui.ShowMessage("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
