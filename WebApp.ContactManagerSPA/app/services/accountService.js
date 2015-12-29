'use strict';

app.factory('Account', ['$resource', '$rootScope', 'Base64', function ($resource, $rootScope, Base64) {
    return $resource('api/Accounts/Register', {
        save: {
            method: 'POST',
            Authorization: 'Basic ' +
                   Base64.encode($rootScope.username + ':' + $rootScope.password)
        }
    });
}]);