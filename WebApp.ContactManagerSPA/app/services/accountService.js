'use strict';

app.factory('Account', function ($resource) {
    return $resource('api/Accounts/:id', { id: '@id' }, {
        get: { method: 'GET' },
        query: { method: 'GET', isArray: true },
        save: { method: 'POST' },
        update: { method: 'PUT' },
        remove: { method: 'DELETE' }
    });
});