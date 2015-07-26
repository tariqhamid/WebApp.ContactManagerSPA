'use strict';

app.factory('contactsService', ['$http', function ($http) {

    var urlBase = 'api/Contacts';
    var factory = {};
    factory.getContacts = function () {
        return $http.get(urlBase);
    };

    factory.getContact = function (id) {
        return $http.get(urlBase + '/' + id);
    };

    factory.updateContact = function (id, contact) {
        return $http.put(urlBase + '/' + id, contact).then(function (status) {
            return status.data;
        });
    };

    factory.addContact = function (contact) {
        return $http.post(urlBase + '/', contact).then(function (status) {
            return status.data;
        });
    };

    factory.deleteContact = function (id) {
        return $http.delete(urlBase + '/' + id).then(function (status) {
            return status.data;
        });
    };

    return factory;
}]);