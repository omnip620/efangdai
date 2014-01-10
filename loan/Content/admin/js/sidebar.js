$(function () {

    var url = location.pathname;
    url = url.split("/");
    var name = url[url.length - 1];

    function getName(s) {
        s = s.split("/");

        return s[s.length - 1];
    }

    $(".page-sidebar-menu a").not(":first").each(function () {
        if (getName($(this).attr("href")) == name || name == "") {
            $(this).addClass("active");
            $(this).parents("li").addClass("active");
            return false;
        }
    })


})

var sideBar = function () {

    return {
        singlePage: function (temp) {
            temp.addClass("active");
            temp.parents("li").addClass("active");
        }

    }
}();