'use strict';

musicApp.factory('allArtistsData', function($http, $log) {
    return {
        getAllArtists: function (successcb) {
            $http({ method: 'GET', url: '/data/all-artists.json' })
            .then(function successCallback(response) {
                successcb(response.data);
            }, function errorCallback(response) {
                $log.error(response);
            });
        }
    };
});
