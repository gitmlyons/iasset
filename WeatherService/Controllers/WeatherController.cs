using WeatherService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.Services.Models;

namespace WeatherService.Controllers
{
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherProviderSerivce _providerService;
        private readonly ILogger _logger;

        public WeatherController(GlobalWeatherService providerService, ILogger<GlobalWeatherService> logger)
        {
            _providerService = providerService;
            _logger = logger;
        }
        
        [HttpGet("CountryCities/{country}")]
        public async Task<MethodResult<List<string>>> CountryCities(string country)
        {
            try
            {
                //var response = await _providerService.CountryCities(country);
                var response = new List<string> { "Sydney", "Melbourne", "Hobart", "Brisbane", "Canberra", "Perth", "Adelaide" };
                return new MethodResult<List<string>>() { Succeeded = true, Result = response };
            }
            catch (Exception ex)
            {
                try { _logger.LogError(ex.ToString()); }
                catch { }

                return new MethodResult<List<string>>() { Succeeded = false, Result = null, Messages = ex.Message };
            }
        }

        //api given in instructions and back up weren't working 
        [HttpGet("{country}/{city}")]
        public async Task<MethodResult<ICityWeather>> Get(string country, string city)
        {
            try
            {
                var response = await _providerService.CityWeather(country, city);
                return new MethodResult<ICityWeather>() { Succeeded = true, Result = response };
            }
            catch (Exception ex)
            {
                try { _logger.LogError(ex.ToString()); }
                catch { }

                return new MethodResult<ICityWeather>() { Succeeded = false, Result = null, Messages = ex.Message };
            }
        }
    }
}
