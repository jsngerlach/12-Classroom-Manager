(function() {
    'use strict';

    angular
        .module('app')
        .controller('ClassDetailController', ClassDetailController);

    ClassDetailController.$inject = ['classFactory', '$stateParams', 'teacherFactory'];

    /* @ngInject */
    function ClassDetailController(classFactory, $stateParams, teacherFactory) {
        var vm = this;
        vm.classEdits = [];
        vm.editClass = editClass;
        vm.teacherOptions = [];


        activate();

        ////////////////

        function activate() {
            classFactory
                .getById($stateParams.id)
                .then(function(response) {
                    vm.classEdits = response.data
                });
            teacherFactory
                .getAll()
                .then(function(response) {
                    vm.teacherOptions = response.data;
                });

        }

        function editClass(id, _class) {
            classFactory
                .update(id, _class);

        }

    }
})();
