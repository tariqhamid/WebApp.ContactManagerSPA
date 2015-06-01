'use strict';

var app = angular.module('ContactManagerApp', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider.when('/contacts', {
        controller: "contactsController",
        templateUrl: "/app/views/contactslist.html"
    })
    .when('/contact/:id', {
        controller: "contactEditController",
        templateUrl: "/app/views/contact.html",
        secure: true
    }).otherwise({ redirectTo: "/contacts" });

}]);