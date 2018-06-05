'use strict';

musicApp.factory('singleData', function($http, $routeParams, $log) {
    return {
        getSingle: function (successcb) {
            $http({ method: 'GET', url: 'http://localhost:56148/api/Single/' + $routeParams.id })
            .then(function successCallback(response) {
                successcb(response.data);
            }, function errorCallback(response) {
                $log.error(response);
            });
        }
    };
});
