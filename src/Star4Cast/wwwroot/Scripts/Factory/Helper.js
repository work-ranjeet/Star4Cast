(function () {
    "use strict";
    // String Functionality
    angular.module("Star4Cast.Factory").factory("Helper", helper);

    function helper($scope, Constants) {

        return {
            Empty: Constants.Empty,

            IsNull: function (value) {
                return value === Constants.NullValue;
            },

            IsNullOrEmpty: function (value) {
                return value === Constants.Empty || value === Constants.NullValue;
            },

            IsNullOrEmptyOrUndefined: function (value) {
                return (typeof value === "undefined") || value === "undefined" || value === Constants.Empty || value === Constants.NullValue || value == Constants.EmptyCellValue;
            },

            IsValidArray: function (value) {
                return angular.isDefined(value) && value != Constants.Empty && value != Constants.NullValue && value.length > 0
                    && angular.isDefined(value[0]) && value[0] != Constants.Empty && value[0] != Constants.NullValue;
            },

            ParseBoolean: paresBoolean

        }



        function paresBoolean(value) {
            if (value == undefined)
                return false;

            if (value.toString().toLowerCase() === "false")
                return false;

            if (value.toString().toLowerCase() === "true")
                return true;

            return false;
        };

    };
});