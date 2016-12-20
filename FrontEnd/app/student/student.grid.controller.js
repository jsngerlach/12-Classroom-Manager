(function() {
    'use strict';

    angular
        .module('app')
        .controller('StudentGridController', StudentGridController);

    StudentGridController.$inject = ['studentFactory'];

    /* @ngInject */
    function StudentGridController(studentFactory) {
        var vm = this;
        vm.studentss = [];
        vm.addStudent = addStudent;
        vm.deleteStudent = deleteStudent;

        activate();

        ////////////////

        function activate() {  //already shown on grid
            studentFactory
                .getAll()
                .then(function(response) {
                    vm.students = response.data
                });
        }

        function addStudent() { 
            studentFactory
            .create(vm.newStudent)
            .then(function(response) {
                vm.students.push(response.data);

                vm.newStudent = {};
            })
            .catch(function(error) {});
        }
        function deleteStudent(student) {  //red x
            studentFactory
                .remove(student.studentId)
                .then(function(response) {
                    var index = vm.students.indexOf(student);

                    vm.students.splice(index, 1);
                })
        }
    }
})();