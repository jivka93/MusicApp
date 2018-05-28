'use strict';

musicApp.controller('AlbumDetailsController',
    function AlbumDetailsController($scope, $routeParams, albumData) {
        var album = albumData.getAlbum($routeParams.id);
        $scope.album = album;
    }
);
