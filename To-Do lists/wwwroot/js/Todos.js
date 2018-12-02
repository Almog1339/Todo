/// <reference path="jquery-3.3.1.js" />

var $tasks = $("#tasks");
var $fname = $('#fname');
var $lname = $('#Lname');
var $gender = $('#gender');
var $birthDate = $('#birthDate');

$("#loginsub").click(function () {

    var url = "api/Login";
    var username = $('#username').val();
    var password = $('#password').val();

    $.get("api/login").done(console.log(JSON.stringify(Response)));

});

$("ul").on("click", "li", function () {
    $(this).toggleClass("completed");
});

$("ul").on("click", "span", function (event) {
    $(this).parent().fadeOut(500, function () {
        $(this).remove();
    });
    event.stopPropagation();
});
$("input[type ='text']").keypress(function (event) {
    if (event.which === 13) {
        var todoText = $(this).val();
        $(this).val("");
        $("ul").append("<li><span><i class='far fa-trash-alt'></i></span>" + todoText + "</li>");
    }
});
$(".fa-pen-fancy").click(function () {
    $("input[type ='text']").fadeToggle();
});
$("button[type='button']").click(function () {
    $("#Signup").fadeToggle();
    $("#login").fadeToggle();

});

