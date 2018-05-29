'use strict';

musicApp.controller('LoginController', function LoginController($scope) {
    $scope.isLogged = false;

    $scope.login = function() {
        var username = $scope.username;
        var password = $scope.password;

        if (username === 'jivka' && password  === '123') {
            $scope.isLogged = true;
        } else {
            alert('Invalid login');
        }
    };

    $scope.logout = function() {
        $scope.isLogged = false;
    };
});
