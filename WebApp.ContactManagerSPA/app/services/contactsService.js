'use strict';
app.factory('Contact', ['$resource', '$rootScope', '$http', 'Base64', function ($resource, $rootScope, $http, Base64) {
    return $resource('api/Contacts/:id', { id: '@id' },{
        get: {
            method: 'GET',
            headers: {
            Authorization: 'Basic ' +
               Base64.encode($rootScope.username + ':' + $rootScope.password)
    }},
        query: {
            method: 'GET',
            isArray: true
        },
        save: {
            method: 'POST',
            headers: {
                Authorization: 'Basic ' +
               Base64.encode($rootScope.username + ':' + $rootScope.password)
            }
        },
        update: {
            method: 'PUT',
            headers: {
                Authorization: 'Basic ' +
               Base64.encode($rootScope.username + ':' + $rootScope.password)
            }
        },
        remove: {
            method: 'DELETE',
            headers: {
                Authorization: 'Basic ' +
               Base64.encode($rootScope.username + ':' + $rootScope.password)
            }
        }
    });
}]);
//app.factory('Contact', function ($resource, $httpProvider, Base64) {
//    $httpProvider.defaults.headers.common['Authorization'] = 'Basic ' + Base64.encode("vasileios@mail.com" + ":" + "vasileios");
//    return $resource('api/Contacts/:id', { id: '@id' }, {
//        get: {method: 'GET'},
//        query: { method: 'GET', isArray: true },
//        save: { method: 'POST' },
//        update: { method: 'PUT' },
//        remove: { method: 'DELETE' }
//    });
//});