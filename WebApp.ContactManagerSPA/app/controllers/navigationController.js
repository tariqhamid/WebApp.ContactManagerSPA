'use strict';

app.controller('navigationController', function ($scope, $location) {
    $scope.register = function () {
        $location.url('/register');
    }
});