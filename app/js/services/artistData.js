'use strict';

musicApp.factory('artistData', function($http, $routeParams, $log) {
    return {
        getArtist: function (successcb) {
            $http({ method: 'GET', url: 'http://localhost:56148/api/Artist/' + $routeParams.id })
            .then(function successCallback(response) {
                successcb(response.data);
            }, function errorCallback(response) {
                $log.error(response);
            });
        }
    };
});


