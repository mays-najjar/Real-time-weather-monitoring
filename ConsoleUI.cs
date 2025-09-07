using System;

namespace Real_time_weather_monitoring
{
    public class ConsoleUI
    {
        public void ShowWelcome()
        {
            Console.WriteLine("Weather Monitoring System Started!");
            Console.WriteLine("Enter weather data (JSON or XML format) or type 'exit' to quit:");
        }

        public string? ReadInput()
        {
            Console.Write("\nEnter weather data: ");
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowError(string error)
        {
            Console.WriteLine(error);
        }
    }
}