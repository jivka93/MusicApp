'use strict';

musicApp.controller('ArtistDetailsController',

    function ArtistDetailsController($scope, artistData) {

        artistData.getArtist(function(data) {
            $scope.artist = data;
        });

        // $scope.artist = artistData.getArtist();

        $scope.showAlbums = false;
        $scope.showAlbumsText = 'Show';
        $scope.showAlbumsInfo = showAlbumsInfo;

       function showAlbumsInfo() {
            if ($scope.showAlbums === false) {
                $scope.showAlbums = true;
                $scope.showAlbumsText = 'Hide';
            } else {
                $scope.showAlbums = false;
                $scope.showAlbumsText = 'Show';
            }
        };
    }
);
