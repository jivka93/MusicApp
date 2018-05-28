'use strict';

var musicApp = angular
.module('musicApp', ['ngResource', 'ngRoute'])
.config(function ($routeProvider) {
    $routeProvider
        .when('/add-artist', {
            templateUrl: 'partials/add-artist.html'

            //, controller: ''
        })
        .when('/artist-details/:id', {
            templateUrl: 'partials/artist-details.html',
            controller: 'ArtistDetailsController'
        })
        .when('/my-profile', {
            templateUrl: 'partials/my-profile.html'
        })
        .otherwise({ retirectTo: '/'});
})
.constant('appName', 'ChalgaParadise');
