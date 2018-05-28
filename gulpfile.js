'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

var source = 'app/scss/*.scss';
var destination = 'app/css/';

gulp.task('sass', function () {
    return gulp.src(source)
      .pipe(sass({ errLogToConsole: true }))
      .on('error', console.error.bind(console))
      .pipe(gulp.dest('app/css/'));
  });
