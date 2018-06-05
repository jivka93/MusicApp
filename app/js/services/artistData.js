'use strict';

musicApp.factory('artistData', function($http, $log) {
    return {
        getArtist: function (successcb) {
            $http({ method: 'GET', url: 'http://localhost:56148/api/Artist/4' })
            .then(function successCallback(response) {
                successcb(response.data);
            }, function errorCallback(response) {
                $log.error(response);
            });
        }
    };
});


