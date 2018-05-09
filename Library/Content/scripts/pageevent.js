var pagenumber = 1;
var rowcount = 2;
$(".page-link").on("click", function () {
    debugger;

    if (pagenumber == 3) {
        $("#pagenext").parent().addClass("disabled");
    }
    if (pagenumber == 1) {
        $("#pageprevious").parent().addClass("disabled");
    }

    $(".page-link").parent().removeClass("active");
    $(this).parent().addClass("active");


    if ($(this).text() == "Previous" && pagenumber > 1) {
        pagenumber -= 1;
        $("#pagenext").parent().removeClass("disabled");
    }

    else if ($(this).text() == "Next" && pagenumber < 3) {

        pagenumber += 1;
        $("#pageprevious").parent().removeClass("disabled");
    }

    else {
        pagenumber = parseInt($(this).text());
    }


    rowcount = 2;
    debugger;
    Paging(pagenumber, rowcount);

});