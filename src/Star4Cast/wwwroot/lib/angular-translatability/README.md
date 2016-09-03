Easy to use Angular JS translation module. It uses natural language strings
for input, while loading and extending languages via JavaScript objects or
remote JSON files.

# Usage

The best way to see how it works is to check out the example in the `example` directory.
Here's a quick overview.

## JavaScript

### Including the module

```javascript
angular.module("myApp", ["angular.translate"])
```

### Including the service in a controller

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "Dictionary", function($scope, Dictionary) {

    $scope.translator = new Dictionary();
    
}]);
```

### Loading a language

Translation files can be defined via JavaScript objects, or loaded via http.

#### Via an object

The key is the phrase to be translated, the value is the translation of that phrase.

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "Dictionary", function($scope, Dictionary) {

    $scope.translator = new Dictionary();
    $scope.translator.add("mk", {
        "Hello": "Zdravo"
    });

}]);
```

#### Via HTTP

If you want to load via http, just use a string representing the url to load.
The endpoint your loading must be JSON.

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "Dictionary", function($scope, Dictionary) {

    $scope.translator = new Dictionary();
    $scope.translator.add("mk", "https://myserver.com/lang/mk.json");

}]);
```

### Dynamically adding phrases

Regardless of how a language was loaded, you can update it after the fact.

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "Dictionary", function($scope, Dictionary) {

    $scope.translator = new Dictionary();
    $scope.translator.add("mk", {
        "Hello": "Zdravo"
    });
    
    // Do lots of stuff.
    
    // Then update.
    $scope.translator.extend("mk", {
        "Bye": "Cao"
    });

}]);
```

### Using a language

The language must be loaded first. When it is, it's simple to switch to it.

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "Dictionary", function($scope, Dictionary) {

    $scope.translator = new Dictionary();
    
    // Switch to a previously loaded language
    $scope.translator.use("sr").then(function() {
    
    });
    
    // To use immediately after loading.
    $scope.translator.add("mk", "https://myserver.com/lang/mk.json").then(function() {
        // Do something after loading and switching to language.
    });
    
    // Add a second parameter to the "use" function (same usage as "add") as a shorthand for add().then()
    $scope.translator.use("mk", "https://server.com/lang/mk.json").then(function() {
        // Do something after loading and switching to language.
    });
    
}]);
```

### Promises

As you've probably noticed by now, every public translator function: `add`, `use`, `extend`, etc returns a promise.

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "Dictionary", function($scope, Dictionary) {

    $scope.translator = new Dictionary();
    $scope.translator.add("mk", "https://server.com/lang/mk.json")
        .then(function() {
            // The language loaded.
        })
        .catch(function() {
            // The file didn't load.
        });
    
}]);
```

If you need to know when multiple languages have loaded, use then Angular's `$q.all` function is perfect:

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "$q", "Dictionary", function($scope, $q, Dictionary) {

    $scope.translator = new Dictionary();
    
    $q.all([
        $scope.translator.add("mk", "https://server.com/lang/mk.json"),
        $scope.translator.add("es", "https://server.com/lang/es.json"),
        $scope.translator.add("sr", "https://server.com/lang/sr.json")
    ]).then(function() {
        // Do something when all languages loaded, perhaps load the language of choice.
    });
    
}]);
```

If you know the user's language preference from the start (via route parameters, for example) 
you could do something like this:

```javascript
angular.module("myApp").controller("myCtrl", ["$scope", "$q", "$routeParams", "Dictionary", function($scope, $q, $routeParams, Dictionary) {

    $scope.translator = new Dictionary();
    
    $q.all([
        $scope.translator.add("mk", "https://server.com/lang/mk.json"),
        $scope.translator.add("es", "https://server.com/lang/es.json"),
        $scope.translator.add("sr", "https://server.com/lang/sr.json")
    ]).then(function() {
        // Do something when all languages loaded, perhaps load the language of choice.
    });
    
    if($routeParams.lang) {
    
        $scope.translator.use($routeParams.lang, "https://server.com/lang/" + $routeParams.lang + ".json")
            .then(function() {
                // The user will now see everything in his language of choice.
            })
            .catch(function() {
                // Didn't load. Perhaps it doesn't exist?
            });
            
    }
    
    // Go ahead and load all languages anyways, if that's how you roll.
    $q.all([
        $scope.translator.add("mk", "https://server.com/lang/mk.json"),
        $scope.translator.add("es", "https://server.com/lang/es.json"),
        $scope.translator.add("sr", "https://server.com/lang/sr.json")
    ]).then(function() {
        // Do something when all languages loaded, perhaps load the language of choice.
    });
    
}]);
```

## HTML

It uses Angular filters to do the translation. If you want dynamic translation, always use
the `translator.current` object for the filter parameter.

```html
<p>{{ "Hello" | translate:translator.current }}</p>
```

It's designed to use strings and default to the string's value, even if the string is
not in the translation file.

For example, the following will return "Hello" even if the phrase isn't in the translation
file:

```html
<p>{{ "Hello" | translate:translator.current }}</p>
```



## Building


