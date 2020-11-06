"use strict";

var gulp = require("gulp"),
    sass = require("gulp-sass");

var path = {
    webroot: "./wwwroot/"
};

gulp.task("sass", function () {
    return gulp.src('Saas/*.scss')
        .pipe(sass())
        .pipe(gulp.dest(path.webroot + '/css'));
});