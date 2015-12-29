'use strict';

angular.module('compare', [])
    .directive('ngcompare', function () {
        return {
            require: "ngModel",
            scope: {
                account: "=ngcompare"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.ngcompare = function (modelValue) {
                    return modelValue === scope.account;
                };

                scope.$watch("account", function () {
                    ngModel.$validate();
                });
            }
        };
    });