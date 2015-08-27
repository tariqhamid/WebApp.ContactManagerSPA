'use strict';

app.controller('registerController', function ($scope, Account, $location) {
    $scope.account = new Account;
    $scope.validation = false;
    $scope.registerAccount = function (registerform) {
        if ($scope.registerform.$invalid) {
            $scope.validation = true;
        }
        else {
            $scope.account.$save();
            $location.url('/contacts');
        }
    }
});