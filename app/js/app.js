'use strict';

var musicApp = angular
.module('musicApp', ['ngResource', 'ngRoute'])
.config(function ($routeProvider, $sceDelegateProvider) {

    $sceDelegateProvider.resourceUrlWhitelist(['^https?:\/\/(localhost:([0-9]+\.)+[a-zA-Z0-9]{1,6})?$', 'self']);

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
        .when('/album-details/:id', {
            templateUrl: 'partials/album-details.html',
            controller: 'AlbumDetailsController'
        })
        .when('/single-details/:id', {
            templateUrl: 'partials/single-details.html',
            controller: 'SingleDetailsController'
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
