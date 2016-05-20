if (!jQuery) { throw new Error("view_result.js requires jQuery") }

$(document).ready(function () {


    // Show/hide html block

    $('#ResultInputClick').click(function () {
        showHide('ResultInput');
        $("html, body").animate({
            scrollTop: 0
        }, 600);

    });

    $('#ResultOutputClick').click(function () {
        showHide('ResultOutput');
        $("html, body").animate({
            scrollTop: 0
        }, 600);

    });

    function showHide(element_id) {
        if (document.getElementById(element_id)) {
            var obj = document.getElementById(element_id);
            if (obj.style.display == "block") {
                obj.style.display = "none";
            }
            else obj.style.display = "block";
        }
    }

});
