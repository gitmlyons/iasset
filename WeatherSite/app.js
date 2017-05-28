
var weatherApp = angular.module('weatherApp', ['ngRoute', 'ui.bootstrap', 'config']);

weatherApp.config(function($routeProvider) {
    $routeProvider.
        when('/', {
            controller: 'WeatherController',
            templateUrl: 'views/weather.html'
        }).
        when('/weather', {
             controller: 'WeatherController',
            templateUrl: 'views/weather.html'
        }).
        otherwise({
            redirectTo: '/weather'
        });
    });
