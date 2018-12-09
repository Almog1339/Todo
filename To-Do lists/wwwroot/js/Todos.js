/// <reference path="jquery-3.3.1.js" />


var tasks = [];



$("#loginsub").click(function () {
    var userData = {
        UserName: $('#username').val(),
        Pass: $('#password').val()
    };
    var url = "api/Login";
    $.post(url, userData).done(
        $('#login').fadeOut(),
        function (data) {
            if (data === -1) {
                $('#Signup').show();
            } else {
                $('#Signup').fadeOut();
                $('#nav').append(" " + userData.UserName);
                $('#container').show(500);
                for (var i = 0; i < data.length; i++) {
                    $('#tasks').append("<li><span><i class='far fa-trash-alt'></i></span>" + data[i].content + "</li>");
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
            console.log(userData.TodoText),
            function (data) {
                if (data === -1) {
                    alert("We could not added new todo to the list cause something went wrong please try again later...");
                } else {
                    $("ul").append("<li><span><i class='far fa-trash-alt'></i></span>" + userData.TodoText + "</li>");
                    console.log(data);
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
    event.stopPropagation();
});

$(".fa-pen-fancy").click(function () {
    $("input[type ='text']").fadeToggle();
});
$("button[type='button']").click(function () {
    $("#Signup").fadeToggle();
    $("#login").fadeToggle();

});

