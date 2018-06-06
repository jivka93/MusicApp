'use strict';

musicApp.controller('SingleDetailsController',

    function SingleDetailsController($scope, trustedFilter, singleData) {

        singleData.getSingle(function(data) {
            $scope.single = data;
        });
    }
);
