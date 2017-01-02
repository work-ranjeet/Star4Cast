(function () {
    'use strict';

    angular
        .module("Star4Cast")
        .controller("ProfileController", profileController);

    //profileController.$inject = ['$scope', 'profile'];

    function profileController($scope, $state, $filter, $location, $window, $q, $sce, $compile, $translate, User, Profile, AjaxService, UrlProvider) {

        $scope.Ajaxtest = [];       
        AjaxService.getData(UrlProvider.User.GetCurrentUserAddress).then(function (result) {
            try {
                if (result != null && result != undefined && result.ErrorCode == undefined) {
                    $scope.Ajaxtest = result;
                }
                else {
                    $rootScope.$broadcast('ajaxresultError', result);
                };
            } catch (e) {
                $rootScope.$broadcast('ajaxError', e);
            }
           
        });

        var batchRequest = [
            AjaxService.getData(UrlProvider.User.GetCurrentUser),
            AjaxService.getData(UrlProvider.User.GetCurrentUserAddress)
        ];
        $q.all(batchRequest).then(function (resultList) {
            //deferred.resolve(resultList);
            if (resultList != null && resultList != undefined && resultList.ErrorCode == undefined) {
                try {
                    var r = resultList;
                }
                catch (e) {
                    $rootScope.$broadcast('ajaxError', e);
                }
            };
        });



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

        $scope.UserAbout = [];
        Profile.GetUserAbout.get(function (result) {
            //$scope.ShowJobCategory = true;
            $scope.UserAbout = result;
        });
    }
})();
