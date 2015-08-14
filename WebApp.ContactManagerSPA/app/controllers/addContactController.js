'use strict';

app.controller('addContactController', function ($scope, Contact, $location) {
    $scope.contact = new Contact;
    $scope.validation = false;
    $scope.addContact = function (contactform) {
        if ($scope.contactform.$invalid) {
            $scope.validation = true;
        }
        else{
            $scope.contact.$save();
            $location.url('/contacts');
        }
    }
});