using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring.Bots
{
    public abstract class BotBase
    {
        protected void PrintActivation(string botName, string message)
        {
            Console.WriteLine($"{botName} activated!");
            Console.WriteLine($"{botName}: \"{message}\"");
        }
    }
}