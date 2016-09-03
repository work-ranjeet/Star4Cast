(function () {
    "use strict";

    angular.module("Star4Cast.Factory").service("User", user);
    //profile.$inject = ['$http'];

    function user($location, $resource, UrlProvider) {
        var getcurrenUser = $resource(UrlProvider.User.GetCurrentUser);
        var getcurrenUserAddress = $resource(UrlProvider.User.GetCurrentUserAddress);
        var getcurrenUserRoles = $resource(UrlProvider.User.GetCurrentUserRoles);

        return {
            CurrentUser: getcurrenUser,
            CurrentUserAddress: getcurrenUserAddress,
            CurrentUserRoles: getcurrenUserRoles
        };


        //var data = $resource(UrlProvider.User.GetUser, { user: '@user' }, { update: { method: 'PUT' } });
        // return $resource(UrlProvider.User.GetUser + '/:id', { id: '@id' });
    }
})();