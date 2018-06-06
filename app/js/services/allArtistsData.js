'use strict';

musicApp.factory('allArtistsData', function($http, $log) {
    return {
        getAllArtists: function (successcb) {
            $http({ method: 'GET', url: 'http://localhost:56148/api/Artist' })
            .then(function (response) {
                successcb(response.data);
            }, function (response) {
                $log.error(response);
            });
        }
    };
});
