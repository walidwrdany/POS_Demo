var minimizeClass = 'kt-aside--minimize';

$(document).on('click', '.kt-aside__brand-aside-toggler', function (e) {
    var hasClass = $('body').hasClass(minimizeClass);
    localStorage.minimize = hasClass;
});

if (localStorage.minimize !== undefined) {
    if (localStorage.minimize === "true") {
        $('body').addClass(minimizeClass);
    } else {
        $('body').removeClass(minimizeClass);
    }
}