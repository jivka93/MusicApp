'use strict';

musicApp.controller('AlbumDetailsController',

    function AlbumDetailsController($scope, albumData) {

        albumData.getAlbum(function(data) {
            $scope.artist = data;
        });
    }
);
