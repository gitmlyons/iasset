using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherService.Configuration;
using WeatherService.Exceptions;
using WeatherService.Services.Models;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using System.Text;

namespace WeatherService.Services
{
    public class GlobalWeatherService : IWeatherProviderSerivce
    {
        private readonly WeatherServiceOptions _weatherServiceOptions;        

        public GlobalWeatherService(IOptionsSnapshot<WeatherServiceOptions> weatherServiceOptionsAccessor)
        {
            _weatherServiceOptions = weatherServiceOptionsAccessor.Value;            
        }

        public async Task<List<string>> CountryCities(string country)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_weatherServiceOptions.GlobalWeatherServiceURL + string.Format(_weatherServiceOptions.GlobalWeatherServiceCountryCitiesURL, country));
                client.Timeout = TimeSpan.FromSeconds(_weatherServiceOptions.WeatherServiceTimeoutSeconds);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_weatherServiceOptions.GlobalWeatherServiceMediaType));

                var response = await SendRawAPIRequest(client);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();                               
                    XmlSerializer ser = new XmlSerializer(typeof(CountryCities));                    
                    return ((CountryCities)ser.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(System.Net.WebUtility.HtmlDecode(responseData.Replace("\r\n", "")))))).Cities.Select(c => c.City).ToList();                    
                }
                else { throw new APICommunicationsCallException(); }
            }
        }
         
        public async Task<ICityWeather> CityWeather(string country, string city)
        {
            //api given in instructions and back up weren't working
            return Models.CityWeather.Mock;
        }

        //Split out mainly to Moq - moq of HttpClient is avoid as unrequired overhead
        public virtual async Task<HttpResponseMessage> SendRawAPIRequest(HttpClient client)
        {
            return await client.GetAsync(string.Empty);
        }
    }
}
