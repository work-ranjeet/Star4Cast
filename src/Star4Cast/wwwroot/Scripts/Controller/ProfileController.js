(function () {
    'use strict';

    angular
        .module("Star4Cast")
        .controller("ProfileController", profileController);

    //profileController.$inject = ['$scope', 'profile'];

    function profileController($scope, $state, $filter, $location, $window, $q, $sce, $compile, $translate, User, Profile) {

        $scope.User = [];
        User.CurrentUser.get(function (result) {
            $scope.User = result;
        });

        $scope.Address = [];
        User.CurrentUserAddress.get(function (result) {
            $scope.Address = result;
        });

       // $scope.ShowJobCategory = false;
        $scope.JobCategory = [];
        Profile.GetJobCategory.query(function (result) {
            //$scope.ShowJobCategory = true;
            $scope.JobCategory = result;
        });

        $scope.CurrentUserJobCategories = [];
        Profile.GetCurrentUserJobCategories.query(function (result) {
            //$scope.ShowJobCategory = true;
            $scope.CurrentUserJobCategories = result;
        });
    }
})();
