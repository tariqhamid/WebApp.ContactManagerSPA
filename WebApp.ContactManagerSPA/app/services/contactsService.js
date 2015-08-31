'use strict';

app.factory('Contact', function ($resource) {
    return $resource('api/Contacts/:id', { id: '@id' }, {
        get: { method: 'GET' },
        query: { method: 'GET', isArray: true },
        save: { method: 'POST' },
        update: { method: 'PUT' },
        remove: { method: 'DELETE' }
    });
});