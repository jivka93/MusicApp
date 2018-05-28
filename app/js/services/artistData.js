'use strict';

musicApp.factory('artistData', function($http, $log) {
    return {
        getArtist: function (successcb) {
            $http({ method: 'GET', url: '/data/artist.json' })
            .then(function successCallback(response) {
                successcb(response.data);
            }, function errorCallback(response) {
                $log.error(response);
            });
        }
    };
});


