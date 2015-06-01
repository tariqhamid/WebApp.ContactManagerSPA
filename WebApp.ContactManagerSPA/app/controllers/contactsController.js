'use strict';

app.controller('contactsController', ['$scope', 'contactsService', function ( $scope, contactsService) {
    
    $scope.contacts;
    getContacts();

    function getContacts() {
        contactsService.getContacts()
            .success(function (conts) {
                $scope.contacts = conts;
            })
            .error(function (error) {
                $scope.status = 'Unable to load contacts list: ' + error.message;
            });
    }
}]);