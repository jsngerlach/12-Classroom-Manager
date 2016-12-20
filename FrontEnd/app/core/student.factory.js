(function() {
    'use strict';

    angular
        .module('app')
        .factory('studentFactory', studentFactory);

    studentFactory.$inject = ['$http'];

    /* @ngInject */
    function studentFactory($http) {
        var service = {
            create: create,
            getAll: getAll,
            getById: getById,
            update: update,
            remove: remove
        };
        return service;

        ////////////////

        function create(student) {
        	return $http.post('http://localhost:52230/api/students', student);
        }
        function getAll(){
        	return $http.get('http://localhost:52230/api/students');
        }
        function getById(id){
        	return $http.get('http://localhost:52230/api/students/' + id);
        }
        function update(id, student){
        	return $http.put('http://localhost:52230/api/students/' + id, student);
        }
        function remove(id){
        	return $http.delete('http://localhost:52230/api/students/' + id);
        }

    }
})();