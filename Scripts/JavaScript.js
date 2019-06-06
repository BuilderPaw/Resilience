function ToTopOfPage(sender, args) {
    // reference: https://stackoverflow.com/questions/7543718/test-in-jquery-if-an-element-is-at-the-top-of-screen
    var distance = $('div').offset().top,
        $window = $(window);

    if ($window.scrollTop() >= distance) {
        $("html, body").animate({ scrollTop: 0 }, 1000);
    }
}

function ToBottomOfPage(sender, args) {
    $("html, body").animate({ scrollTop: $(document).height() }, 1000);
}

function FadeInReport(sender, args) {
    $("html, body").fadeOut(50);
    $("html, body").fadeIn(230);
}

function ShowProgress() {
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        $('#body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 1.2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);
}

function HideProgress() {
    // method to be called if user hasn't tick the Sign Manager Checkbox
}

function pageLoad(sender, args) {
    $("#btnSearchReport").click(function () {
        if (Page_ClientValidate("Search")) // check Validation Group - Search before loading the gif icon
            $(".header").after("<img src='/Images/loading.gif' style='position:fixed; margin: 10% 6%; width:100px; height:80px; z-index:4;' alt='loading' />");
    });

    $("#btnSearchReport1").click(function () {
        if (Page_ClientValidate("Search")) // check Validation Group - Search before loading the gif icon
            $(".header").after("<img src='/Images/loading.gif' style='position:fixed; margin: 10% 6%; width:100px; height:80px; z-index:4;' alt='loading' />");
    });
}