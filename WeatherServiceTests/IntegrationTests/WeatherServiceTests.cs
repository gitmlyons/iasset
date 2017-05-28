using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using WeatherService.Configuration;
using WeatherService.Controllers;
using WeatherService.Services;

namespace CreditCardAPITests.IntegrationTests
{
    [TestClass]
    public class WeatherServiceTests
    {
        IOptionsSnapshot<WeatherServiceOptions> _options;
        WeatherController _weatherController;

        [TestInitialize]
        public void TestInitialise()
        {
            _options = MockLoadAppSettings();
            _weatherController = MockWeatherController(_options);
        }

        #region test cases
        [TestMethod]
        public async Task WeatherServiceGetCountries()
        {            
            var result = await _weatherController.CountryCities("Australia");

            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Result.Count() != 0 && result.Result[0] != null);
        }

        [TestMethod]
        public async Task WeatherServiceGetWeather()
        {         
            var result = await _weatherController.Get("Australia", "Sydney");

            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Result != null);
        }
        #endregion

        #region setup testing
        private IOptionsSnapshot<WeatherServiceOptions> MockLoadAppSettings()
        {
            var _options = new WeatherServiceOptions()
            {
                GlobalWeatherServiceURL = "http://www.webservicex.net/globalweather.asmx/",
                GlobalWeatherServiceMediaType = "application/soap+xml",
                WeatherServiceTimeoutSeconds = 30,
                GlobalWeatherServiceCountryCitiesURL = "GetCitiesByCountry?CountryName={0}",
                GlobalWeatherServiceCityWeatherURL = "GetWeather?CityName={0}&CountryName={1}"
            };

            var _mock = new Mock<IOptionsSnapshot<WeatherServiceOptions>>();
            _mock.Setup(m => m.Value).Returns(_options);

            return _mock.Object;
        }

        private WeatherController MockWeatherController(IOptionsSnapshot<WeatherServiceOptions> _options)
        {
            var mockGlobalWeatherService = new GlobalWeatherService(_options);

            //defaults to silent logger
            ILoggerFactory loggerFactory = new LoggerFactory().AddSerilog(new LoggerConfiguration().CreateLogger());
            var logger = loggerFactory.CreateLogger<GlobalWeatherService>();
            return new WeatherController(mockGlobalWeatherService, logger);
        }
        #endregion
    }
}
