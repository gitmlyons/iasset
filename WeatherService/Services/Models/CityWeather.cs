using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.Services.Models
{
    public class CityWeather : ICityWeather
    {
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public float Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyConditions { get; set; }
        public float Temperature { get; set; }
        public float DewPoint { get; set; }
        public float RelativeHumidity { get; set; }
        public float Pressure { get; set; }

        public static CityWeather Mock
        {
            get
            {
                return new CityWeather
                {
                    DewPoint = 25,
                    Location = "Location",
                    Pressure = 1013,
                    RelativeHumidity = 60,
                    SkyConditions = "Sky Conditions",
                    Temperature = 20,
                    Time = DateTime.Now,
                    Visibility = "50 km",
                    Wind = 13
                };
            }
        }
    }
}
