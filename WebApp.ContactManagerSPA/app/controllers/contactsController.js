'use strict';

app.controller('contactsController', contactsController);
contactsController.$inject=['$scope', 'contactsService'];

function contactsController($scope, contactsService) {
    $scope.getContacts = function() {
        contactsService.getContacts()
            .success(function (data, status, headers, config) {
                $scope.contacts = data;
            })
            .error(function (data, status, headers, config) {
                $scope.status = 'Unable to load contacts list: ' + data.Message;
            });
    };

    $scope.deleteContact = function (id) {
        contactsService.deleteContact(id);
        alert('ok');
    }
}

//app.controller('contactsController', ['$scope', 'contactsService', function ($scope, contactsService) {
//    $scope.getContacts = function() {
//        contactsService.getContacts()
//            .success(function (data, status, headers, config) {
//                $scope.contacts = data;
//            })
//            .error(function (data, status, headers, config) {
//                $scope.status = 'Unable to load contacts list: ' + data.Message;
//            });
//    };

//    $scope.deleteContact = function (id) {
//        contactsService.deleteContact(id);
//        alert('ok');
//    }
//}]);