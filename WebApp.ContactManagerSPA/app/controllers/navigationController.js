'use strict';

app.controller('navigationController', ['$window', '$scope', '$state', '$rootScope', function ($window, $scope, $state, $rootScope) {
    $scope.logoutUser = function () {
        $window.localStorage.removeItem("jwt_token");
        $state.go("login");
    };
}]);