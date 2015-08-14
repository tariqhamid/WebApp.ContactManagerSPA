'use strict';

app.controller('editContactController', function ($scope, $location, Contact, $routeParams) {
    
    $scope.contact = Contact.get({ id: $routeParams.id });
    $scope.validation = false;
    $scope.addContact = function (contactform) {
        if ($scope.contactform.$invalid) {
            $scope.validation = true;
        }
        else {
            $scope.contact.$save();
            $location.url('/contacts');
        }
    }
});