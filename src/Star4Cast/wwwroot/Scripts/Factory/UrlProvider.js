(function () {
    "use strict";

    angular.module("Star4Cast.Factory").factory("UrlProvider", urlProvider);
    //urlProvider.$inject = ["Helper", 'Constants'];

    function urlProvider($location) {
        this._domain = $location.protocol() + "://" + $location.host() + ":" + $location.port();

        return {
            User: {
                GetCurrentUser: this._domain + "/web/User/GetCurrent",
                GetCurrentUserAddress: this._domain + "/web/User/GetCurrentUserAddress",
                GetCurrentUserRoles: this._domain + "/web/User/GetRoles"

            },
            Profile: {
                GetJobCategory: this._domain + "/web/Profile/GetJobCategory",
                GetCurrentUserJobCategories: this._domain + "/web/Profile/GetCurrentUserJobCategories"
            }
        }

    }
})();
















//(function () {
//    'use strict';

//    angular.module("Star4Cast.Constant")
//        .value("UrlProvider",
//        {
//            _domain:"",
//            User: {
//                GetUser: "/web/User/GetCurrent"
//            },
//            Profile: {}
//        });
//})();



//(function () {
//    'use strict';
//    angular.module("Star4Cast").config(function ($provide) {


//        $provide.decorator("UrlProvider",
//            function ($delegate, $location) {
//                var domain = $location.protocol() + "://" + $location.host() + ":" + $location.port();
//                angular.forEach($delegate, function (outerItem) {
//                    angular.forEach(outerItem, function (item) {
//                       return  domain + item;
//                    });
//                });
//            });
//    });
//})();