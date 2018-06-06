'use strict';

musicApp.controller('RegisterUserController', function RegisterUserController($scope) {

    $scope.showPasswordError = false;

    $scope.registerUser = function() {

        var password = $scope.user.password;
        var repeatPassword = $scope.user.passwordVerify;

        if (password !== repeatPassword) {
            $scope.showPasswordError = true;
        } else {

            $scope.showPasswordError = false;

            var user = {
                username: $scope.user.username,
                password: $scope.user.password
            };

        }

    };
});
