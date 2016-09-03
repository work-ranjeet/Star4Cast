var fs = require("fs");

module.exports = function(config) {

  // Use ENV vars on Travis and sauce.json locally to get credentials
  if (! process.env.SAUCE_USERNAME) {
    if (! fs.existsSync("sauce.json")) {
      console.log("Create a sauce.json with your credentials.");
      process.exit(1);
    } else {
      process.env.SAUCE_USERNAME = require("./sauce").username;
      process.env.SAUCE_ACCESS_KEY = require("./sauce").accessKey;
    }
  }

  // Check out https://saucelabs.com/platforms for all browser/platform combos
  var customLaunchers = {
    "SL_Chrome": {
      base: "SauceLabs",
      browserName: "chrome",
      platform: "Linux"
    },
    "SL_Chrome_beta": {
      base: "SauceLabs",
      browserName: "chrome",
      platform: "Linux",
      verion: "beta"
    },
    "SL_IE": {
      base: "SauceLabs",
      browserName: "internet explorer"
    },
    "SL_IE_10": {
      base: "SauceLabs",
      browserName: "internet explorer",
      version: "10"
    },
    "SL_IE_9": {
      base: "SauceLabs",
      browserName: "internet explorer",
      version: "9"
    },
    "SL_IE_8": {
      base: "SauceLabs",
      browserName: "internet explorer",
      version: "8"
    },
    "SL_Firefox": {
      base: "SauceLabs",
      browserName: "firefox"
    },
    "SL_Firefox_beta": {
      base: "SauceLabs",
      browserName: "firefox",
      version: "beta"
    },
    "SL_safari_ios8": {
      base: "SauceLabs",
      browserName: "iphone",
      platform: "OS X 10.9",
      version: "8.1"
    },
    "SL_safari_ios7": {
      base: "SauceLabs",
      browserName: "iphone",
      platform: "OS X 10.9",
      version: "7.1"
    },
    "SL_safari_ios6": {
      base: "SauceLabs",
      browserName: "iphone",
      platform: "OS X 10.8",
      version: "6.1"
    },
    "SL_android": {
      base: "SauceLabs",
      browserName: "android"
    },
    "SL_android_4_4": {
      base: "SauceLabs",
      browserName: "android",
      platform: "linux",
      version: "4.4"
    },
    "SL_android_4_3": {
      base: "SauceLabs",
      browserName: "android",
      platform: "linux",
      version: "4.3"
    },
    "SL_android_4_2": {
      base: "SauceLabs",
      browserName: "android",
      platform: "linux",
      version: "4.2"
    },
    "SL_android_4_1": {
      base: "SauceLabs",
      browserName: "android",
      platform: "linux",
      version: "4.1"
    },
    "SL_android_4_0": {
      base: "SauceLabs",
      browserName: "android",
      platform: "linux",
      version: "4.0"
    },
    "SL_safari": {
      base: "SauceLabs",
      browserName: "safari",
      platform: "OS X 10.10"
    },
    "SL_safari_7": {
      base: "SauceLabs",
      browserName: "safari",
      platform: "OS X 10.9",
      version: "7"
    },
    "SL_opera": {
      base: "SauceLabs",
      browserName: "Opera",
      platform: "Linux"
    }
  };

  config.set({
    basePath: "",
    frameworks: ["jasmine"],
    files: [
      "src/js/source.js",
      "test/unit/**/*.spec.js"
    ],
    reporters: ["dots", "saucelabs"],
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,
    sauceLabs: {
      testName: "angular-translate unit tests"
    },
    captureTimeout: 240000,
    customLaunchers: customLaunchers,
    browsers: Object.keys(customLaunchers),
    singleRun: true
  });
};
