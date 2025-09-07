## **General Task Description**

Design and implement a C# console application that simulates a real-time weather monitoring and reporting service. The system receives and processes raw weather data in multiple formats (JSON, XML, etc.) from various weather stations for different locations. The application includes different types of 'weather bots', each configured to behave differently based on the weather updates it receives.

---
[![build and test](https://github.com/mays-najjar/Real-time-weather-monitoring/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/mays-najjar/Real-time-weather-monitoring/actions/workflows/build-and-test.yml)

## **Supported Input Formats**

### **JSON Format**
```json
{
    "Location": "City Name",
    "Temperature": 23.0,
    "Humidity": 85.0
}
```

### **XML Format**
```xml
<WeatherData>
    <Location>City Name</Location>
    <Temperature>23.0</Temperature>
    <Humidity>85.0</Humidity>
</WeatherData>
```

The system should allow for the addition of new data formats with minimal changes, demonstrating the Open-Closed principle of SOLID design.

---

## **Different Bot Types**

1. **RainBot**: Activated when humidity exceeds a configured limit. Prints a pre-configured message.
2. **SunBot**: Activated when temperature rises above a configured limit. Prints a pre-configured message.
3. **SnowBot**: Activated when temperature drops below a configured limit. Prints a pre-configured message.

---

## **Example Interaction**

- User starts the application.
- System prompts: `Enter weather data:`
- User enters JSON or XML weather data.
- System activates bots according to the provided data and configuration.

Example output:
```
SunBot activated!
SunBot: "Wow, it's a scorcher out there!"
```

---

## **Configuration Details**

All bot settings are controlled via a JSON configuration file, including enable/disable, activation thresholds, and output messages.

Example configuration:
```json
{
    "RainBot": {
        "enabled": true,
        "humidityThreshold": 70,
        "message": "It looks like it's about to pour down!"
    },
    "SunBot": {
        "enabled": true,
        "temperatureThreshold": 30,
        "message": "Wow, it's a scorcher out there!"
    },
    "SnowBot": {
        "enabled": false,
        "temperatureThreshold": 0,
        "message": "Brrr, it's getting chilly!"
    }
}
```

---

## **Additional Notes**

- Interns should implement reading the configuration file at startup and adjust bot behavior accordingly.
- The task involves applying Observer and Strategy design patterns, handling file I/O, and supporting multiple data formats.
- The application should be extensible for new bot types or data formats with minimal code changes.
