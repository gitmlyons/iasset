(function () {
    'use strict';

    angular
        .module('weatherApp')
        .factory('WeatherService', WeatherService);

    WeatherService.$inject = ['$http', 'apiURL'];
    function WeatherService($http, apiURL) {
        var service = {};

        service.CountryCities = CountryCities;
        service.CityWeather = CityWeather;

        return service;

        function CountryCities(country, callback) {
		$http({
			method: 'GET',
			url: apiURL + '/CountryCities/' + country,
			headers: {
				"Content-Type": "application/json"
			}
		}).then(function successCallback(response) {
			callback(response.data);
		}, function errorCallback(response) {			
			callback({ succeeded: false, messages: 'Cannot access Weather Service.'  });
		});
        }        

        function CityWeather(country, city, callback) {
		$http({
			method: 'GET',
			url: apiURL + '/' + country + '/' + city,
			headers: {
				"Content-Type": "application/json"
			}
		}).then(function successCallback(response) {
			callback(response.data);
		}, function errorCallback(response) {
			callback({ succeeded: false, messages: 'Cannot access Weather Service.'  });
		});
        }      
    }

})();