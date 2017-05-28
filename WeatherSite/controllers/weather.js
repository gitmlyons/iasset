'use strict';

angular.module('weatherApp')

.controller('WeatherController',
    ['$scope', 'WeatherService',
    function ($scope, WeatherService) {
	$scope.userHasClicked = false;

        $scope.CountryCities = function () {
            $scope.userHasClicked = true;
	    $scope.error = '';
            $scope.cities = null;
	    $scope.city = null;
            $scope.weather = null;

            WeatherService.CountryCities($scope.country, function (response) {
		if (response.succeeded)
		{
                    $scope.cities = response.result;
		    $scope.city = $scope.cities[0];		     
		}
		else
                    $scope.error = response.messages;

		$scope.userHasClicked = false;
           });
        };

        $scope.CityWeather = function () {
            $scope.userHasClicked = true;
	    $scope.error = '';
	    $scope.weather = null;

            WeatherService.CityWeather($scope.country, $scope.city, function (response) {
		if (response.succeeded)
		{
                    $scope.weather = response.result;
		}
		else
                    $scope.error = response.messages;

		$scope.userHasClicked = false;
           });
        };

    }]);