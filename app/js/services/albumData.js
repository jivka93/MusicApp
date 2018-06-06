'use strict';

musicApp.factory('albumData', function($http, $routeParams, $log) {
    return {
        getAlbum: function (successcb) {
            $http({ method: 'GET', url: 'http://localhost:56148/api/Album/' + $routeParams.id })
            .then(function successCallback(response) {
                successcb(response.data);
            }, function errorCallback(response) {
                $log.error(response);
            });
        }
    };
});
