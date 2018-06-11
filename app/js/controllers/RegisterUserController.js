'use strict';

musicApp.controller('RegisterUserController',
    function RegisterUserController($scope, $http, $sce) {

        $scope.showPasswordError = false;

        $scope.registerUser = function() {
            var password = $scope.user.password;
            var repeatPassword = $scope.user.passwordVerify;

            if (password !== repeatPassword) {
                $scope.reset();
                $scope.showPasswordError = true;
            } else {
                $scope.showPasswordError = false;

                var url = 'http://localhost:56148/User';

                var config = {
                    method: 'POST',
                    url: $sce.trustAsResourceUrl(url),
                    data: {
                        'Username': $scope.user.username,
                        'Password': $scope.user.password
                     },
                    headers: {
                        'Content-Type': 'application/json;'
                    }
                };

                $http(config)
                    .then(function success(response) {
                        console.log('success!');
                    }, function error(response) {
                        console.log('error!');
                    }
                );
            }
        };

        $scope.reset = function() {
            $scope.user.password = '';
            $scope.user.passwordVerify = '';
            $scope.showPasswordError = true;
        };
    }
);

