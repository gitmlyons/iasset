using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using WeatherService.Services.Models;

namespace WeatherService.Services
{
    public interface IWeatherProviderSerivce
    {
        Task<List<string>> CountryCities(string country);
        Task<ICityWeather> CityWeather(string country, string city);
        Task<HttpResponseMessage> SendRawAPIRequest(HttpClient client);
    }
}
