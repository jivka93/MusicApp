'use strict';

musicApp.factory('allArtistsData', function($http, $log) {
    return {
        getAllArtists: function (successcb) {
            $http({ method: 'GET', url: '/data/all-artists.json' })
            .then(function (response) {
                successcb(response.data);
            }, function (response) {
                $log.error(response);
            });
        }
    };
});
