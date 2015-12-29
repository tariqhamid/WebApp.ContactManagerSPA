'use strict';

app.controller('registerController', function ($window, $scope, Account, $state) {
    var storage = $window.localStorage;
    $scope.account = new Account;
    $scope.validation = false;
    $scope.registerAccount = function (registerform) {
        if ($scope.registerform.$invalid) {
            $scope.validation = true;
        }
        else {
            if (!storage.getItem("jwt_token")) {
                $scope.account.$save().then (function(response) {
                        console.log(response);
                        $window.localStorage.setItem("jwt_token", response.token);
                    }).then(function(error) {
                        console.log(error);
                        $window.localStorage.removeItem("jwt_token");
                    })
                }
            }
            
            //$scope.account.$save().then(function (response) {
            //    $state.go('root.contacts');
            //});
        }
});