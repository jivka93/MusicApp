'use strict';

musicApp.controller('ArtistDetailsController',
    // function ArtistDetailsController($scope, $routeParams, artistData) {
    function ArtistDetailsController($scope) {
        // var artist = artistData.getArtist($routeParams.id);
    
        var artist = {
            id: 1,
            name: 'Преслава',
            label: 'Планета Пайнер',
            image: 'https://www.marica.bg/images/158/640_158326.jpeg',
            albumsCount: 6,
            singlesCount: 39,
            albums: [
                {
                    title: 'Преслава',
                    image: 'https://i49.vbox7.com/o/639/6398dbb5e60.jpg',
                    year: 2004,
                    songs: 16
                },
                {
                    title: 'Дяволско желание',
                    image: 'https://img.discogs.com/dTK63zJQ9tHH_mWCWioB9BLRrzw=/fit-in/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-6044135-1409624871-5654.jpeg.jpg',
                    year: 2005,
                    songs: 12
                },
                {
                    title: 'Интрига',
                    image: 'http://www.preslavadaily.net/wp-content/uploads/2017/08/200601.jpg',
                    year: 2007,
                    songs: 12
                },
                {
                    title: 'Не съм ангел',
                    image: 'http://www.polymusic.eu/images/thumbs/0009010.jpeg',
                    year: 2007,
                    songs: 12
                },
                {
                    title: 'Пази се от приятелки',
                    image: 'https://i49.vbox7.com/o/0df/0df5c69d210.jpg',
                    year: 2009,
                    songs: 14
                },
                {
                    title: 'Как ти стои',
                    image: 'http://store.picbg.net/pubpic/D3/7C/a63c4e4d3202d37c.jpg',
                    year: 2011,
                    songs: 13
                }
            ]           
        };

        $scope.artist = artist;
        $scope.showAlbums = false;
        $scope.showAlbumsText = 'Show';
        $scope.showAlbumsInfo = showAlbumsInfo;

       function showAlbumsInfo() {
            if ($scope.showAlbums === false) {
                $scope.showAlbums = true;
                $scope.showAlbumsText = 'Hide';
            }
            else {
                $scope.showAlbums = false;
                $scope.showAlbumsText = 'Show';
            }
        };
    }
);