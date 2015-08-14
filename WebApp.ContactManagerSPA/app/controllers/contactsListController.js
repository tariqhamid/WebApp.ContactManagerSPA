(function () {
    'use strict';

    app.controller('contactsListController', function ($scope, $location, Contact) {
        $scope.contacts = Contact.query();

        $scope.remove = function (id, rev) {
            Contact.remove({
                id: id,
                rev: rev
            });
        }

        $scope.edit = function (id) {
            $location.url('/contact' + id);
        }
    });
}());