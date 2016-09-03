/* global require: false, __dirname: false */
"use strict";

// Include Gulp & Tools We"ll Use
var gulp = require("gulp"),
    uglify = require("gulp-uglify"),
    size = require("gulp-size"),
    concat = require("gulp-concat"),
    jshint = require("gulp-jshint"),
    stylish = require("jshint-stylish"),
    glob = require("glob"),
    karma = require("gulp-karma"),
    rename = require("gulp-rename"),
    runSequence = require("run-sequence"),
    connect = require("gulp-connect");

function p(src) {
    return __dirname + (src.charAt(0) === "/" ? "" : "/") + src;
}

gulp.task("lint", function () {
    return gulp.src("./angular-translate.js")
        .pipe(jshint())
        .pipe(jshint.reporter("jshint-stylish"))
        .pipe(jshint.reporter("fail"));
});

gulp.task("jshint", function () {
    return gulp.src(p("angular-translate.js"))
        .pipe(jshint())
        .pipe(jshint.reporter("jshint-stylish"))
        .pipe(connect.reload());
});

gulp.task("uglify", function() {
    return gulp.src(p("angular-translate.js"))
        .pipe(uglify())
        .pipe(rename("angular-translate.min.js"))
        .pipe(gulp.dest(p("/")));
});

gulp.task("build", function() {
    runSequence("lint", "uglify");
});

gulp.task("watch", ["test"], function() {
    gulp.watch("./angular-translate.js", ["jshint", "uglify"]);
});

gulp.task("test", function() {
    gulp.src([
        "./bower_components/angular/angular.min.js",
        "./angular-translate.min.js"
    ])
    .pipe(karma({
        configFile: "karma.conf.js",
        action: "watch"
    }));
});

gulp.task("connect", function() {
    connect.server({
        port: 8000
    });
});

gulp.task("default", ["connect"], function() {
    runSequence("build", "watch");
});
