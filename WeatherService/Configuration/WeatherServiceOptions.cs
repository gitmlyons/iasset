using System.Collections.Generic;

namespace WeatherService.Configuration
{
    public class WeatherServiceOptions
    {
        public WeatherServiceOptions() { }
        public string GlobalWeatherServiceURL { get; set; }
        public string GlobalWeatherServiceCountryCitiesURL { get; set; }
        public string GlobalWeatherServiceCityWeatherURL { get; set; }
        public string GlobalWeatherServiceMediaType { get; set; }
        public string OpenWeatherServiceURL { get; set; }
        public string OpenWeatherServiceCityWeatherURL { get; set; }
        public string OpenWeatherServiceMediaType { get; set; }
        public int WeatherServiceTimeoutSeconds { get; set; }        
    }
}
