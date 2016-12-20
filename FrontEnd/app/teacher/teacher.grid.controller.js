(function() {
    'use strict';

    angular
        .module('app')
        .controller('TeacherGridController', TeacherGridController);

    TeacherGridController.$inject = ['teacherFactory'];

    /* @ngInject */
    function TeacherGridController(teacherFactory) {
        var vm = this;
        vm.teachers = [];
        vm.addTeacher = addTeacher;
        vm.deleteTeacher = deleteTeacher;

        activate();

        ////////////////

        function activate() {  //already shown on grid
            teacherFactory
                .getAll()
                .then(function(response) {
                    vm.teachers = response.data
                });
        }

        function addTeacher() {  
            teacherFactory
            .create(vm.newTeacher)
            .then(function(response) {
                vm.teachers.push(response.data);

                vm.newTeacher = {};
            })
            .catch(function(error) {});
        }
        function deleteTeacher(teacher) {  //red x
            teacherFactory
                .remove(teacher.teacherId)
                .then(function(response) {
                    var index = vm.teachers.indexOf(teacher);

                    vm.teachers.splice(index, 1);
                })
        }
    }
})();