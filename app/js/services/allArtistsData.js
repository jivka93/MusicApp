'use strict';

musicApp.factory('allArtistsData', function($http, $log) {
    return {
        getAllArtists: function (successcb) {
            $http({ method: 'GET', url: '/data/all-artists.json' })
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
