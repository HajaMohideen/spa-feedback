(function (app) {
    'use strict';

    app.controller('usersCtrl', usersCtrl);

    usersCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function usersCtrl($scope, apiService, notificationService) {

        $scope.saveUser = saveUser;

        function saveUser() {
            //console.log($scope.user);
            apiService.post('/api/users/add/', $scope.user,
                            saveUserCompleted,
                            saveUserLoadFailed);
        }

        function saveUserCompleted(response) {
            notificationService.displaySuccess($scope.user.username + ', user feedback has been updated');
            $scope.user = {};
            $modalInstance.dismiss();
        }

        function saveUserLoadFailed(response) {
            notificationService.displayError(response.data);
        }
    }

})(angular.module('homeCinema'));
