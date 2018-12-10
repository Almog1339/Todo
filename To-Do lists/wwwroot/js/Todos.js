/// <reference path="jquery-3.3.1.js" />
var tasks = [];

$("#loginsub").click(function () {
    var userData = {
        UserName: $('#username').val(),
        Pass: $('#password').val()
    };
    $.post("api/Login", userData).done(
        $('#login').fadeOut(),
        function (data) {
            if (data === -1) {
                $('#Signup').show();
            } else {
                $('#Signup').fadeOut();
                $('#nav').append(" " + userData.UserName);
                $('#container').show(500);
                for (var i = 0; i < data.length; i++) {
                    $('#tasks').append("<li id='TodoTextContent'><span><i class='far fa-trash-alt'></i></span>" + data[i].content + "</li>");
                }
            }
        });
});

$("input[type ='text']").keypress(function (event) {
    if (event.which === 13) {
        var userData = {
            UserName: $('#username').val(),
            TodoText: $('#todoText').val()
        };
        $.post("api/Tickets", userData).done(
            function (data) {
                if (data === -1) {
                    alert("We could not added new todo to the list cause something went wrong please try again later...");
                    $("#todoText").empty();
                } else {
                    $("#tasks").append("<li id='TodoTextContent'><span><i class='far fa-trash-alt'></i></span>" + userData.TodoText + "</li>");
                    $("#todoText").empty();
                }
            });
    }
});


$("ul").on("click", "li", function () {
    $(this).toggleClass("completed");
});

$("ul").on("click", "span", function (event) {
    $(this).parent().fadeOut(500, function () {
        $(this).remove();
    });
    console.log($('#TodoTextContent').valueOf());
    //var userData = {
    //    UserName: $('#username').val(),
    //    TodoText: $('data[i].content').val()
    //};

    //$.ajax({
    //    method: "Delete",
    //    url: "api/Tickets",
    //    data: userData
    //}).done(
    //    function (data) {
    //        if (data === -1 || data === false) {
    //            alert("please try again later...");
    //        } else {
    //            consle.log("Done");
    //        }
    //    });
    event.stopPropagation();
});

$(".fa-pen-fancy").click(function () {
    $("input[type ='text']").fadeToggle();
});

$("button[type='button']").click(function () {
    $("#Signup").fadeToggle();
    $("#login").fadeToggle();
});