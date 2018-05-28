'use strict';

var musicApp = angular
.module('musicApp', ['ngResource', 'ngRoute'])
.config(function ($routeProvider) {
    $routeProvider
        .when('/add-artist', {
            templateUrl: 'partials/add-artist.html'

            //, controller: ''
        })
        .when('/artist-details', {
            templateUrl: 'partials/artist-details.html',
            controller: 'ArtistDetailsController'
        })
        .when('/artist-details/:id', {
            templateUrl: 'partials/artist-details.html',
            controller: 'ArtistDetailsController'
        })
        .when('/', {
            templateUrl: 'partials/all-artists.html',
            controller: 'AllArtistsController'
        })
        .when('/my-profile', {
            templateUrl: 'partials/my-profile.html'
        })
        .otherwise({ retirectTo: '/'});
})
.constant('appName', 'ChalgaParadise');
