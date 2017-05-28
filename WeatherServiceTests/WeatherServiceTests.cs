using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.Configuration;
using WeatherService.Controllers;
using WeatherService.Services;

namespace CreditCardAPITests
{
    [TestClass]
    public class WeatherServiceTests
    {
        IOptionsSnapshot<WeatherServiceOptions> _options;

        [TestInitialize]
        public void TestInitialise()
        {
            _options = MockLoadAppSettings();
        }

        #region test cases
        [TestMethod]
        public async Task WeatherServiceGetCountries()
        {
            var weatherController = MockWeatherControllerAndResponse(_options,
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<string xmlns=\"http://www.webserviceX.NET\">&lt;NewDataSet&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Archerfield Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Amberley Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Alice Springs Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Brisbane Airport M. O&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Coolangatta Airport Aws&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Cairns Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Charleville Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Gladstone&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Longreach Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Mount Isa Amo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Mackay Mo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Oakey Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Proserpine Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Rockhampton Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Broome Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Townsville Amo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Weipa City&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Gove Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Tennant Creek Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Yulara Aws&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Albury Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Devonport East&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Goldstream Aws&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;East Sale Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Hobart Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Launceston Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Laverton Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Moorabbin Airport Aws&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Mount Gambier Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Mildura Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Melbourne Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Macquarie Island&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Wynyard West&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Adelaide Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Albany Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Broken Hill Patton Street&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Ceduna Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Derby&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Darwin Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Bullsbrook Pearce Amo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Edinburgh M. O.&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Forrest Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Geraldton Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Kalgoorlie Boulder Amo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Kununurra Kununurra Aws&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Leigh Creek Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Learmonth Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Meekatharra Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Port Hedland Pardoo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Parafield Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Belmont Perth Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Katherine Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Woomera Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Bankstown Airport Aws&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Canberra&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Coffs Harbour Mo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Cooma&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Camden Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Dubbo&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Norfolk Island Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Nowra Ran Air Station&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Richmond Aus-Afb&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Sydney Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Tamworth Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Wagga Airport&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n  &lt;Table&gt;\r\n    &lt;Country&gt;Australia&lt;/Country&gt;\r\n    &lt;City&gt;Williamtown Aerodrome&lt;/City&gt;\r\n  &lt;/Table&gt;\r\n&lt;/NewDataSet&gt;</string>",
                System.Net.HttpStatusCode.OK);
            var result = await weatherController.CountryCities("Australia");

            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Result.Count() != 0 && result.Result[0] != null);
        }

        [TestMethod]
        public async Task WeatherServiceGetCountriesFailNoData()
        {
            var weatherController = MockWeatherControllerAndResponse(_options,
                "",
                System.Net.HttpStatusCode.OK);
            var result = await weatherController.CountryCities("Australia");

            Assert.IsTrue(!result.Succeeded);            
        }

        [TestMethod]
        public async Task WeatherServiceGetCountriesFailNoConnectivity()
        {
            var weatherController = MockWeatherControllerAndResponse(_options,
                "",
                System.Net.HttpStatusCode.NotFound);
            var result = await weatherController.CountryCities("Australia");

            Assert.IsTrue(!result.Succeeded);
            Assert.IsTrue(result.Messages == WeatherService.Exceptions.APICommunicationsCallException.DefaultFailureMessage);
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

        private WeatherController MockWeatherControllerAndResponse(IOptionsSnapshot<WeatherServiceOptions> _options, string response, System.Net.HttpStatusCode status)
        {
            var mockHttpResponseMessage = new HttpResponseMessage(status);
            mockHttpResponseMessage.Content = new StringContent(response);
            var mockGlobalWeatherService = new Mock<GlobalWeatherService>(_options) { CallBase = true };
            mockGlobalWeatherService.Setup(c => c.SendRawAPIRequest(
                It.IsAny<HttpClient>()
                )).Returns(Task.FromResult(mockHttpResponseMessage));


            //defaults to silent logger
            ILoggerFactory loggerFactory = new LoggerFactory().AddSerilog(new LoggerConfiguration().CreateLogger());
            var logger = loggerFactory.CreateLogger<GlobalWeatherService>();
            return new WeatherController(mockGlobalWeatherService.Object, logger);
        }
        #endregion
    }
}
