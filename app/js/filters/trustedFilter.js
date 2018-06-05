MusicApp.filter('trusted', ['$sce', function ($sce) {
    return $sce.trustAsResourceUrl;
 }]);
