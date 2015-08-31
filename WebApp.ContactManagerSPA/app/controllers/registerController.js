'use strict';

app.controller('registerController', function ($scope, Account, $state) {
    $scope.account = new Account;
    $scope.validation = false;
    $scope.registerAccount = function (registerform) {
        if ($scope.registerform.$invalid) {
            $scope.validation = true;
        }
        else {
            $scope.account.$save();
            $state.transitionTo('root.contacts');
        }
    }
});