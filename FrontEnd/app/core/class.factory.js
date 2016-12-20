(function() {
    'use strict';

    angular
        .module('app')
        .factory('classFactory', classFactory);

    classFactory.$inject = ['$http'];

    /* @ngInject */
    function classFactory($http) {
        var service = {
            create: create,
            getAll: getAll,
            getById: getById,
            update: update,
            remove: remove
        };
        return service;

        ////////////////

        function create(_class) {
        	return $http.post('http://localhost:52230/api/classes', _class);
        }
        function getAll(){
        	return $http.get('http://localhost:52230/api/classes');
        }
        function getById(id){
        	return $http.get('http://localhost:52230/api/classes/' + id);
        }
        function update(id, _class){
        	return $http.put('http://localhost:52230/api/classes/' + id, _class);
        }
        function remove(id){
        	return $http.delete('http://localhost:52230/api/classes/' + id);
        }

    }
})();