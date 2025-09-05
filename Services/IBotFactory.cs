using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_time_weather_monitoring.Bots;
using Real_time_weather_monitoring.Models;

namespace Real_time_weather_monitoring.Services
{
    public interface IBotFactory
    {
        List<IWeatherBot> CreateBots(BotConfiguration config);

    }
}