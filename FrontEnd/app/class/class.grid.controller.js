(function() {
    'use strict';

    angular
        .module('app')
        .controller('ClassGridController', ClassGridController);

    ClassGridController.$inject = ['classFactory'];

    /* @ngInject */
    function ClassGridController(classFactory) {
        var vm = this;
        vm.classes = [];
        vm.addClass = addClass;
        vm.deleteClass = deleteClass;

        activate();

        ////////////////

        function activate() {  //already shown on grid
            classFactory
                .getAll()
                .then(function(response) {
                    vm.classes = response.data
                });
        }

        function addClass() {  //addclass button
            classFactory
            .create(vm.newClass)
            .then(function(response) {
                vm.classes.push(response.data);

                vm.newClass = {};
            })
            .catch(function(error) {});
        }
        function deleteClass(_class) {  //red x
            classFactory
                .remove(_class.classId)
                .then(function(response) {
                    var index = vm.classes.indexOf(_class);

                    vm.classes.splice(index, 1);
                })
        }
    }
})();