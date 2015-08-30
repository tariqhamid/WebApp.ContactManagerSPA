'use strict';

var app = angular.module('contactManagerApp', ['ui.router', 'ngResource', 'ngMessages', 'ui.bootstrap', 'confirm', 'compare']);
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
        .when('/contact/id=:id', {
            controller: 'editContactController',
            templateUrl: 'app/views/editContact.html'
        }).when('/register', {
            controller: 'registerController',
            templateUrl: 'app/views/registerAccount.html'
        })
        .otherwise({ redirectTo: "/contacts" });

    $locationProvider.html5Mode(true);
});
