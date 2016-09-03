(function () {
    'use strict';

    angular.module("Star4Cast.Constant")
        .constant("Constants",
        {
            Empty: "",
            EmptyValue: "-",
            NullValue: null,
            Unknown: "Unknown",
            NotApplicable: "NA",
            DataFormat: {
                Url: "url",
                Text: "text",
                Percent: "percent",
                PercentChange: "percentChange",
                Money: "money",
                Date: "date",
                Function: "function",
                Json: "json",
                Number: "Number"
            },
            SearchType: {
                StartsWith: "startwith"
            },
            HTMLTemplate: {
            }

        });
});