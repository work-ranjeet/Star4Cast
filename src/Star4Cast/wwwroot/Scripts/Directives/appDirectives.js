angular.module('Star4Cast.Directives').
    directive('capitalizeFirst', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, modelCtrl) {
                var capitalize = function (inputValue) {
                    var capitalized = inputValue.toUpperCase();
                    if (capitalized !== inputValue) {
                        modelCtrl.$setViewValue(capitalized);
                        modelCtrl.$render();
                    }
                    return capitalized;
                }
                modelCtrl.$parsers.push(capitalize);
                capitalize(scope[attrs.ngModel]);  // capitalize initial value
            }
        };
    })
    .directive('showonhoverparent', function () {
        return {
            link: function (scope, element, attrs) {
                element.parent().bind('mouseenter', function () {
                    element.show();
                });
                element.parent().bind('mouseleave', function () {
                    element.hide();
                });
            }
        };
    })
    .directive('disableAutoClose', function () {
        // directive for disabling the default
        // close on 'click' behavior
        return {
            link: function ($scope, $element) {
                $element.on('click', function ($event) {

                    $event.stopPropagation();
                });
            }
        };
    })
 .directive('compile', ['$compile', function ($compile) {
     return function ($scope, element, attrs) {
         $scope.$watch(
           function (scope) {
               return scope.$eval(attrs.compile);
           },
           function (value) {
               element.html(value);
               $compile(element.contents())(scope);
           }
        )
     };
 }])
.directive('dynAttr', function () {
    return {
        scope: { list: '=dynAttr' },
        link: function (scope, elem, attrs) {
            for (attr in scope.list) {
                elem.attr(scope.list[attr].attr, scope.list[attr].value);
            }
            //console.log(scope.list);           
        }
    };
})
.directive('postRepeatDirective', ['$timeout', '$log', function ($timeout, $log) {
    return function (scope, element, attrs) {
        if (scope.$last) {
            $timeout(function () {
                console.info("DOM rendering took: " + (new Date().getTime() - currentTime) + " MS");
            });
        }
    };
}]);

