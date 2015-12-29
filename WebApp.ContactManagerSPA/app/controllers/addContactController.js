'use strict';

app.controller('addContactController', function ($scope, $state, Contact) {
    $scope.contact = new Contact;
    $scope.validation = false;
    $scope.addContact = function (contactform) {
        if ($scope.contactform.$invalid) {
            $scope.validation = true;
        }
        else {
            $scope.contact.$save().then(function () {
                $state.transitionTo('root.contacts', {}, { reload: true });
            });
        }
    };
});