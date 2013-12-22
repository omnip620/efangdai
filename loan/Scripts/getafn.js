$(function () {
    $("[href='aboutus.html']:first").addClass("current");
    var url = location.pathname;
    url = url.split("/");
    var name = url[url.length - 1];


    $(".fr a").each(function () {
        if ($(this).attr("href") == name) {
            $(this).addClass("current");
            return false;
        }
    })
})