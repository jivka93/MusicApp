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

                var url = 'http://localhost:56148/User/';

                var user = {
                    username: $scope.user.username,
                    password: $scope.user.password
                };

                var json = JSON.stringify(user);

                var config = {
                    method: 'POST',
                    data: json,
                    headers : {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json;'
                    }
                }


                var promise = $http.post($sce.trustAsResourceUrl(url), [config]);

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

