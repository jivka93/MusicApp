'use strict';

musicApp.factory('artistData', function($http, $log) {
    return {
        getArtist: function (successcb) {
            $http({ method: 'GET', url: '/data/artist.json' })
            .then(function successCallback(response) {
                console.log(response);
                successcb(response.data);
            }, function errorCallback(response) {
                console.log(response);
                $log.error(response);
            });
        }
    };
});


