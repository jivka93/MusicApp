'use strict';

musicApp.controller('AddArtistController',
    function AddArtistController($scope) {
        $scope.showSuccessAlert = true;
        $scope.showErrorAlert = true;

        $scope.addArtist = addArtist;

        var addArtist = function() {
            alert('saved');
            console.log('saved');
        };
    }
);
