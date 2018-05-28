'use strict';

// musicApp.factory('artistData', function($http, $log) {
//     return {
//         getArtist: function (id, successcb) {
//             $http({method: 'GET', url: '/data/artist/' + id})
//                 .success(function (data, status, headers, config) {
//                     successcb(data);
//             })
//                 .error(function (data, status, headers, config) {
//                     $log.error(data);
//             });
//         }
//     };
// });

// musicApp.factory('artistData', function($http, $log) {
//     return {
//         getArtist: function (id, successcb) {
//             $http({ method: 'GET', url: '/data/artist/' + id })
//             .then(function successCallback(response) {
//                 successCallback(response);
//             }, function errorCallback(response) {

//             });
//         }
//     };
// });

musicApp.factory('artistData', function($http) {
    var artist = {
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
                id: 5,
                title: 'Пази се от приятелки',
                image: 'https://i49.vbox7.com/o/0df/0df5c69d210.jpg',
                year: 2009,
                songs: 14
            },
            {
                id: 6,
                title: 'Как ти стои',
                image: 'http://store.picbg.net/pubpic/D3/7C/a63c4e4d3202d37c.jpg',
                year: 2011,
                songs: 13
            }
        ]};

    var factory = {};

    factory.getArtist = function() {
        return artist;
    };

    return factory;
});

