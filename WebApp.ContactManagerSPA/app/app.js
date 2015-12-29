'use strict';

var app = angular.module('contactManagerApp', ['ui.router', 'ngResource', 'ngMessages','confirm', 'compare']);
app.config(function ($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
    $stateProvider
        .state('root', {
            abstract:true,
            url: '',
            views: {
                'header': {
                    templateUrl: 'app/views/templates/header.html'
                },
                'footer': {
                    templateUrl: 'app/views/templates/footer.html'
                }
            },
            data: {
                requireLogin: true
            }
        })
        .state('root.contacts', {
            url: '/contacts',
            views: {
                'header': {
                    templateUrl: 'app/views/templates/header.html'
                },
                'footer': {
                    templateUrl: 'app/views/templates/footer.html'
                },
                '@': {
                    templateUrl: 'app/views/contactsList.html',
                    controller: 'contactsListController'
                }
            }
        })
        .state('root.addcontact', {
            url: '/contact',
            views: {
                '@': {
                    templateUrl: 'app/views/addcontact.html',
                    controller: 'addContactController'
                }
            }
        })
        .state('root.editcontact', {
            url: '/contact/id=:id',
            views: {
                '@': {
                    templateUrl: 'app/views/editcontact.html',
                    controller: 'editContactController'
                }
            }
        })
        .state('root.register', {
            url: '/register',
            views: {
                '@': {
                    templateUrl: 'app/views/register.html',
                    controller: 'registerController'
                }
            }
        })
        .state('login', {
            url: '/login',
            views: {
                '': {
                    templateUrl: 'app/views/login.html',
                    controller: 'loginController'
                }
            },
            data: {
                requireLogin: false
            }
        });
    $urlRouterProvider.otherwise('/login');

    $locationProvider.html5Mode(true).hashPrefix('!');

    $httpProvider.interceptors.push('authInterceptor');
});
app.run(function ($rootScope, $state) {
    // register listener to watch route changes
    $rootScope.$on("$stateChangeStart", function (event, toState) {
        if (!$rootScope.isAuthenticated && toState.name != 'login') {
            $state.go('login');
            event.preventDefault();
            return;
        }
    });
});