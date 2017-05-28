using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherService.Services.Models
{
    public interface ICityWeather
    {
        string Location { get; set; }
        DateTime Time { get; set; }
        float Wind { get; set; }
        string Visibility { get; set; }
        string SkyConditions { get; set; }
        float Temperature { get; set; }
        float DewPoint { get; set; }
        float RelativeHumidity { get; set; }
        float Pressure { get; set; }
    }
}
