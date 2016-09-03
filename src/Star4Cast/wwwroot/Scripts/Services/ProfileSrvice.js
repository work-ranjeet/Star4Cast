(function () {
    "use strict";

    angular.module("Star4Cast.Factory").service("Profile", profile);
    //profile.$inject = ['$http'];

    function profile($location, $resource, UrlProvider) {
        var getJobCategory = $resource(UrlProvider.Profile.GetJobCategory);
        var getcurrenUserAddress = $resource(UrlProvider.User.GetUser);
        return {
            GetJobCategory: getJobCategory,
            GetCurrentUserJobCategories: $resource(UrlProvider.Profile.GetCurrentUserJobCategories)
        }

        
        
        //var data = $resource(UrlProvider.User.GetUser, { user: '@user' }, { update: { method: 'PUT' } });
        // return $resource(UrlProvider.User.GetUser + '/:id', { id: '@id' });
    }
})();