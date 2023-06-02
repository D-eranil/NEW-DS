let path = window.location.pathname;

if (path) {
    if (path.indexOf('/') != -1) {
        let slashCount = path.split('/').length - 1;
        if (slashCount === 1) {

            $('.nav-item').each(function (i, e) {
                $('.nav-item').removeClass('active-header');
            });

            $('.nav-item').each(function (i, e) {
                let urlGetPath = $(this).children().attr('href');

                if (urlGetPath && path.toLocaleLowerCase() === urlGetPath.toLocaleLowerCase()) {
                    $(this).children().css('color','#F05A22');
                }
            });
        }
    }
}