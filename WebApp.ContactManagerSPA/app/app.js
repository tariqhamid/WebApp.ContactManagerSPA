'use strict';

var app = angular.module('contactManagerApp', ['ngRoute', 'ngResource', 'ngMessages', "ui.bootstrap"]);
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/contacts', {
            controller: 'contactsListController',
            templateUrl: 'app/views/contactsList.html'
        })
        .when('/contact', {
            controller: 'addContactController',
            templateUrl: 'app/views/addContact.html'
        })
        .when('/contact:id', {
            controller: 'editContactController',
            templateUrl: 'app/views/editContact.html'
        })
        .otherwise({ redirectTo: "/contacts" });

    $locationProvider.html5Mode(true);
});
