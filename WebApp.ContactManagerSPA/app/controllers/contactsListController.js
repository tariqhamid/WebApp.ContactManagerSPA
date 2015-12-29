'use strict';

app.controller('contactsListController', function ($scope, $state, Contact) {
    $scope.contacts = Contact.query();

    $scope.remove = function (id, rev) {
        Contact.remove({
            id: id,
            rev: rev
        }).$promise.then(function () {
            $state.go($state.current, {}, { reload: true });
        });
    };
});
