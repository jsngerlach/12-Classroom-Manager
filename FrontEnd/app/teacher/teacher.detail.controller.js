(function() {
    'use strict';

    angular
        .module('app')
        .controller('TeacherDetailController', TeacherDetailController);

    TeacherDetailController.$inject = [];

    /* @ngInject */
    function TeacherDetailController() {
        var vm = this;
        vm.title = 'TeacherDetailController';

        activate();

        ////////////////

        function activate() {
        }
    }
})();