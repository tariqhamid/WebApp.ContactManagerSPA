'use strict';

app.controller('contactEditController', contactEditController);
contactEditController.$inject = ['$scope', '$location', '$routeParams', 'contactsService'];

function contactEditController($scope, $location, $routeParams, contactsService) {
    $scope.loadContact = function () {
        contactsService.getContact(contactId)
        .success(function (data, status, headers, config) {
            $scope.contact = data;
        })
        .error(function (error) {
            $scope.status = 'Unable to load contact with id=' + contactId + error.message;
        });
    }
}


//app.controller('contactEditController', ['$scope', '$location', '$routeParams', 'contactsService', function ($scope, $location, $routeParams, contactsService) {
    
//    var contact = $scope.contact;
//    var contactId = ($routeParams.id) ? $routeParams.id : "";
//    if(contactId) getContact(contactId);
//    $scope.loading = false;
//    function getContact(contactId) {
//        contactsService.getContact(contactId)
//            .success(function (data, status, headers, config) {
//                $scope.contact = data;
//            })
//            .error(function (error) {
//                $scope.status = 'Unable to load contact with id=' + contactId + error.message;
//            });
//    };

//    $scope.saveContact = function () {
//        var contact = $scope.contact;
//        var response = $scope.response;
//        $scope.loading = true;
//        if (!contactId) {
//            contactsService.addContact(contact)
//                .then(function (responseResult) {
//                    $scope.loading = false;
//                    $location.path('/contacts');
//            })
//            .then(function (error) {
//                $scope.status = 'Unable to save contact';
//            });
//        }
//        else {
//            contactsService.updateContact(contactId,contact)
//            .then(function (responseResult) {
//                contact._rev = responseResult.rev;
//                $scope.loading = false;
//                $location.path('/contacts');
//            })
//            .then(function (error) {
//                $scope.status = 'Unable to load contact with id=' + contactId;
//            });
//        }
//    };
//}]);