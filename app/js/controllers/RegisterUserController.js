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
                var user = {
                    username: $scope.user.username,
                    password: $scope.user.password
                };

                var config = {
                    headers : {
                        'Content-Type': 'application/json;'
                    }
                }

                var url = 'http://localhost:56148/api/User';
                var promise = $http.jsonp($sce.trustAsResourceUrl(url));

                // $http.jsonp('http://localhost:56148/api/User', [config])
                //     .then(function(response) {
                //         // success callback
                //         console.log("Sent Orders Successfully!")
                // });

                // $http.jsonp('http://localhost:56148/api/User', user)
                // .then(function(response) {
                //     // success callback
                //     console.log("Sent Orders Successfully!")
                // },
                // function(response) {
                //     // failure call back
                //      console.log("Error while sending orders")
                // });
            }
        };

        $scope.reset = function() {
            $scope.user.password = '';
            $scope.user.passwordVerify = '';
            $scope.showPasswordError = true;
        };
    }
);

