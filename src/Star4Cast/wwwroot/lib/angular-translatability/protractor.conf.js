var env = require("./environment.js");

// Tests for an Angular app where ng-app is not on the body.
exports.config = {
    seleniumAddress: env.seleniumAddress,
    framework: "jasmine2",
    specs: ["tests/e2e/**/*.spec.js"],
    capabilities: env.capabilities,
    baseUrl: env.baseUrl,
    rootElement: "html",
    jasmineNodeOpts: {
        defaultTimeoutInterval: 600000,
        reporters: ["progress"],
        silent: true
    },
    allScriptsTimeout: 300000,
    onPrepare: function() {

    }
};