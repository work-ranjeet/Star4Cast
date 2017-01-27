angular.module('Star4Cast.Factory').factory('AjaxService', function ($http, $q) {
    return {
        getPostData: function (url, postdata) {
            var deferred = $q.defer();
            $http.post(url, postdata)
              .then(function (result) {
                  deferred.resolve(result.data);
              });
            return deferred.promise;
        },
        getData: function (url, locale) {
            var deferred = $q.defer();
            $http.get(url)
              .then(function (result) {
                  deferred.resolve(result.data);
              });
            return deferred.promise;
        }
    }
});