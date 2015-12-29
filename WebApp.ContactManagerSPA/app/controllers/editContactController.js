'use strict';

app.controller('editContactController', function ($scope, $state, Contact, $stateParams) {

    $scope.contact = Contact.get({ id: $stateParams.id });
    $scope.validation = false;
    $scope.addContact = function (contactform) {
        if ($scope.contactform.$invalid) {
            $scope.validation = true;
        }
        else {
            $scope.contact.$save();
            $state.transitionTo('root.contacts');
        }
    };
});