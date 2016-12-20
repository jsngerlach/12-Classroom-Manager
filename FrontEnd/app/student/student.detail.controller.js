(function() {
    'use strict';

    angular
        .module('app')
        .controller('StudentDetailController', StudentDetailController);

    StudentDetailController.$inject = [];

    /* @ngInject */
    function StudentDetailController() {
        var vm = this;
        vm.title = 'StudentDetailController';

        activate();

        ////////////////

        function activate() {
        }
    }
})();