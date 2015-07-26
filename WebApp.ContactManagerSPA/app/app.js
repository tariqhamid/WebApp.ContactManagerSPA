'use strict';

var app = angular.module('ContactManagerApp', ['ngRoute']);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    
    $routeProvider.when('/contacts', {
        controller: "contactsController",
        templateUrl: "/app/views/contactslist.html"
    })
    .when('/contact/:id', {
        controller: "contactEditController",
        templateUrl: "/app/views/contact.html",
        secure: true
    })
    .when('/contact', {
        controller: "contactEditController",
        templateUrl: "/app/views/contact.html",
    }).otherwise({ redirectTo: "/contacts" });

    // use the HTML5 History API
    $locationProvider.html5Mode(true);
}]);