(function () {
    'use strict';

    app.controller('contactsListController', function ($scope, $location, Contact, $modal) {
        $scope.contacts = Contact.query();

        $scope.remove = function (id, rev) {
            Contact.remove({
                id: id,
                rev: rev
            }).$promise.then(function () {
                $scope.contacts = Contact.query();
            });
        }

        $scope.edit = function (id) {
            $location.url('/contact/id=' + id);
        }
    });
}());