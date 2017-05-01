﻿var domain = window.location.pathname;
domain = domain.substr(0, domain.lastIndexOf('/'));

$(document).ready(function ($) {
    // for right click functinoality
    const HIDDEN_MENU_WIDTH_OFFSET = 130;
    const HIDDEN_MENU_HEIGHT_OFFSET = 80;
    $(".hidden-menu").hide();
    $(".clickable-row").click(function () {
        window.location = domain + $(this).data("href");
    });
    $('*').click(function (e) {
        if (e.target.className != 'clickable-row') {
            $(".hidden-menu").hide();
        }
    });
    $(".clickable-row").contextmenu(function (e) {
        var rowId = $(this).attr("id");
        $('.hidden-menu li a').attr('href', function (i, str) {
            return domain + str + rowId;
        });
        $(".hidden-menu").css({ position: "absolute", top: e.pageY - HIDDEN_MENU_HEIGHT_OFFSET, left: e.pageX - HIDDEN_MENU_WIDTH_OFFSET });
        $(".hidden-menu").toggle();
        return false;
    });
});