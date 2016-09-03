(function () {

    'use strict';
   
    angular.module("Star4Cast.Directives", []);
    angular.module("Star4Cast.Services", []);
    angular.module("Star4Cast.Filters", []);
    angular.module("Star4Cast.Factory", []);
    angular.module("Star4Cast.Formatter", []);
    angular.module("Star4Cast.Constant", []);
    //angular.module('StarIn.Preferences', ['preferences']);

    angular.module("Star4Cast.Common", ["pascalprecht.translate",
        "Star4Cast.Directives",
        "Star4Cast.Services",
        "Star4Cast.Filters",
        "Star4Cast.Factory",
        "Star4Cast.Formatter",
        "Star4Cast.Constant"
        //'AnalystApp.Preferences'
    ]);


    var module = angular.module("Star4Cast",
    [
        "ngAnimate",
        "ui.bootstrap",
        "ui.router",
        'ngResource',
        //'preferences',
        "Star4Cast.Common"
    ]);


    module.config(function ($stateProvider, $urlRouterProvider, $translateProvider, $httpProvider) {
        $translateProvider.translations("en-us", EN_US);

        //var userSettings = preferencesProvider.getUserSettings();
        $translateProvider.preferredLanguage("en-us");
        $(document.body).addClass("en-us");


        //    $stateProvider
        //        .state('starin', {
        //            url: '/analyst',
        //            templateUrl: '',
        //            controller: '',
        //            data: {
        //                PageTabTitle: "",
        //                ProfileType: Components.ProfileContainer,
        //                BetaBarWhatsChanging: BetaBarTemplate.AppTemplate
        //            }
        //        });
    });
})();

