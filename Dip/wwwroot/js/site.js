// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#chkShow").before(function () {
        if ($(this).is(":checked")) {
            $("#cShow").show();
           
        } else {
            $("#cShow").hide();
           
        }
    });
    $("#chkShow").click(function () {
        if ($(this).is(":checked")) {
            $("#cShow").show();

        } else {
            $("#cShow").hide();

        }
    });
});

$(".collapse").on('show.bs.collapse', function () {
    $(".collapse").collapse('hide');
});