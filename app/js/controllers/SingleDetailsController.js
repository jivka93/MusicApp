'use strict';

musicApp.controller('SingleDetailsController',

    function SingleDetailsController($scope, singleData) {

        singleData.getSingle(function(data) {
            $scope.single = data;
        });
    }
);
