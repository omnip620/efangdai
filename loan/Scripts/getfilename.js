


$(function () {

    var url = location.pathname;
    url = url.split("/");
    var name = url[url.length - 1];

    function getName(s) {
        s = s.split("/");
        return s[s.length - 1];
    }

    $(".nav a").each(function () {

        
        if (getName($(this).attr("href")) == name || name == "") {
            $(this).addClass("current");
            return false;
        }
    })


})


