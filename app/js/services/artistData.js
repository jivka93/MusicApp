'use strict';

// musicApp.factory('artistData', function($http, $log) {
//     return {
//         getArtist: function (id, successcb) {
//             $http({ method: 'GET', url: '/data/artists.json' })
//             .then(function successCallback(response) {
//                 successCallback(response);
//             }, function errorCallback(response) {
//                 $log.error(response);
//             });
//         }
//     };
// });

musicApp.factory('artistData', function($http, $log) {
    var factory = {};

    factory.getArtist = function (id, successcb) {
        $http({ method: 'GET', url: '/data/artists.json' })
        .then(function successCallback(response) {
            successCallback(response);
        }, function errorCallback(response) {
            $log.error(response);
        });

    return factory;
};
});

var obj = {
    id: 1,
    name: 'Преслава',
    label: 'Планета Пайнер',
    image: 'https://www.marica.bg/images/158/640_158326.jpeg',
    albumsCount: 6,
    singlesCount: 39,
    albums: [
        {
            id: 1,
            title: 'Преслава',
            image: 'https://i49.vbox7.com/o/639/6398dbb5e60.jpg',
            year: 2004,
            songs: 16
        },
        {
            id: 2,
            title: 'Дяволско желание',
            image: 'https://img.discogs.com/dTK63zJQ9tHH_mWCWioB9BLRrzw=/fit-in/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-6044135-1409624871-5654.jpeg.jpg',
            year: 2005,
            songs: 12
        }
    ]
};

