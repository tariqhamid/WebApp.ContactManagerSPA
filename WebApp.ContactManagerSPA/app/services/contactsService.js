'use strict';

app.service('contactsService', ['$http', function ($http) {

    var urlBase = 'api/Contacts';
    this.getContacts = function () {
        return $http.get(urlBase);
    };

    this.getContact = function (id) {
        return $http.get(urlBase + '/' + id);
    };

    this.saveContact = function (id, contact) {
        return $http.put(urlBase + '/' + id, contact);
    };
}]);