'use strict';
app.factory('authInterceptor', [
            '$rootScope','$window', function ($rootScope, $window) {
                $rootScope.isAuthenticated = false;
                var storage = $window.localStorage;
                return {
                    request: function(config) {
                        var token = storage.getItem("jwt_token");
                        if (token) {
                            config.headers.Authorization = "Bearer" + " " + token;
                        }
                        return config;
                    },

                    response: function(response) {
                        return response;
                    }
                };
            }
]);