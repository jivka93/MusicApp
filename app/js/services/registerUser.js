'use strict';

musicApp.factory('registerUser', function($http, user) {
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
