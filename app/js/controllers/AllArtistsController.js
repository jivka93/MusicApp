'use strict';

musicApp.controller('AllArtistsController',

    function AllArtistsController($scope, allArtistsData) {

        allArtistsData.getAllArtists(function(data) {
            $scope.allArtists = data;
        });

        $scope.addFavouriteArtist = addFavouriteArtist;

        var addFavouriteArtist = function(artistId) {

        };
    }
);
