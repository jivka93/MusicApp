'use strict';

musicApp.controller('AllArtistsController',

    function AllArtistsController($scope, allArtistsData) {

        allArtistsData.getAllArtists(function(data) {
            $scope.allArtists = data;
        });

        $scope.addFavouriteArtist = addFavouriteArtist;

        function addFavouriteArtist(artistId) {
            console.log(artistId);
        };
    }
);
