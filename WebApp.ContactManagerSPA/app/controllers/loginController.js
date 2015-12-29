'use strict';

app.controller('loginController', function ($scope, $rootScope, User, Authentication, $state, $window) {
    var storage = $window.localStorage;
    $scope.user = new User;
    $scope.validation = false;
    $scope.loginUser = function (loginform) {
        if ($scope.loginform.$invalid) {
            $scope.validation = true;
        }
        else {
            if (!storage.getItem("jwt_token")) {
                $scope.user.$save().then(
                    function (response) {
                        $rootScope.isAuthenticated = true;
                        $window.localStorage.setItem("jwt_token", response.token);
                        $state.go('root.contacts');
                    },
                    function (error) {
                        $rootScope.isAuthenticated = false;
                        console.log(error);
                    });
            }

            //$scope.user.$save().then(function () {
            //    $rootScope.loggedIn = true;
            //}).then(function () {
            //    $rootScope.username = $scope.user.email;
            //    $rootScope.password = $scope.user.password;
            //}).then(function () {
            //    $state.go('root.contacts');
            //});

        }
    };
});