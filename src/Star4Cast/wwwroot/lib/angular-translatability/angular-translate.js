angular.module("angular.translate", [])
    .factory("Dictionary", ["$http", "$q", "$timeout", function ($http, $q, $timeout) {

        return function Dictionary() {

            var self = this;

            this.current = {};
            this.language = false;
            this.languages = {};

            this.extend = function(lang, phrases) {

                var deferred = $q.defer();

                $timeout(function() {

                    if(! self.languages[lang]) {
                        self.languages[lang] = {};
                    }

                    angular.extend(self.languages[lang], phrases);

                    deferred.resolve(self.languages[lang]);
                });

                return deferred.promise;

            };

            this.add = function (lang, src) {

                var deferred = $q.defer();



                $timeout(function() {

                    if(! self.languages[lang]) {
                        self.languages[lang] = {};
                    }

                    if(angular.isObject(src)) {
                        angular.extend(self.languages[lang], src);
                        deferred.resolve(self.languages[lang]);
                    } else if("string" === typeof src) {
                        $http.get(src)
                            .then(function(data) {
                                angular.extend(self.languages[lang], data.data);
                                deferred.resolve(self.languages[lang]);
                            }).catch(function() {
                                deferred.reject("Could not get file");
                            });
                    } else {
                        deferred.reject("[angular-translate] Invalid source: " + src.toString());
                    }

                });


                return deferred.promise;

            };

            // This is a private function. Don't use it.
            this.switchTo = function(lang) {

                if (self.languages[lang]) {
                    self.language = lang;
                    self.current = self.languages[lang];
                    return self.current;
                } else {
                    return false;
                }

            };

            this.use = function (lang, src) {

                var deferred = $q.defer();

                if(src) {
                    this.load(lang.src)
                        .then(function() {
                            var langObj = self.switchTo(lang);
                            if(success) {
                                deferred.resolve(langObj);
                            } else {
                                deferred.reject("Could not load language " + lang);
                            }
                        })
                        .catch(deferred.reject);
                } else {
                    deferred.resolve(self.switchTo(lang));
                }

                return deferred.promise;

            };

        };

    }])
    .filter("translate", ["$log", function($log) {

        return function(str, language) {
            return language && language[str] ? language[str] : str;
        };

    }]);

