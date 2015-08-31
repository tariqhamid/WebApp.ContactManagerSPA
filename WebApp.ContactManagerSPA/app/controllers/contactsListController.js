'use strict';

app.controller('contactsListController', function ($scope, $state, Contact) {
    $scope.contacts = Contact.query();
});