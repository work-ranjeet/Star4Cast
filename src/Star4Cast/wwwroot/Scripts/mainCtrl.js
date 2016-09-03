(function () {
    "use strict";
    angular.module("Star4Cast").controller("mainCtrl", mainCtrl);
    function mainCtrl($scope, $state, $filter, $http, $location, $window, $q, $sce, $compile, $translate, UrlProvider) {
        var parent = this;
        $scope.WebName = "Star4Cast";
        

        $scope.$on("$stateChangeSuccess", function (ev, toState) {
            var currentState = $state.current;
            //if (currentState && currentState.data && currentState.data.PageTabTitle) {
            //    $translate(currentState.data.PageTabTitle)
			//		.then(function (title) {
			//		    $scope.PageTabTitle = title;
			//		})
			//		.catch(function () {
			//		    $scope.PageTabTitle = currentState.data.PageTabTitle;
			//		})
			//		.finally(function () {
			//		    $scope.updateTitle();
			//		});
            //}
        });

    };
})();

