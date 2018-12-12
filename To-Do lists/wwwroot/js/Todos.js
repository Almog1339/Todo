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
                    $('#tasks').append("<li id='TodoTextContent'><span id=" + i + "><i class='far fa-trash-alt'></i></span>" + data[i].content + "</li>");
                    tasks[i] = data[i];
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
                    $("input[type = 'text']").empty();
                } else {
                    $("#tasks").append("<li id='TodoTextContent'><span><i class='far fa-trash-alt'></i></span>" + userData.TodoText + "</li>");
                    $("input[type = 'text']").empty();
                }
            });
    }
});

$("#submitbtn").click(function () {

    var userData = {
        UserName: $('#RegUserName').val(),
        Pass: $('#signPass').val(),
        FName: $("#Fname").val(),
        LName: $("#Lname").val()
    };

    $.post("api/Registration", userData).done(
        function (data) {
            if (data === -1) {
                alert("Hi " +
                    userData.UserName +
                    " Unfortunately we have run some issues....Please try again later..");
            } else {
                alert("Success Please try to login now");
            }
        });
});

$("ul").on("click", "li", function () {
    $(this).toggleClass("completed");
});

$("ul").on("click", "span", function () {
    $(this).parent().fadeOut(1500, function () {
        $(this).remove();
    });

    var userData = {
        UserName: $('#username').val(),
        TodoTextId: $('this.id').val(),
        TodoText: tasks[this.id].content
    };
    $.ajax({
        method: "DELETE",
        url: "api/Tickets",
        data: userData
    }).done(
        function (data) {
            if (data === -1) {
                alert("We have run with some issue please try again later...");
            }
        });
    event.stopPropagation();
});

$(".fa-pen-fancy").click(function () {
    $("input[type ='text']").fadeToggle();
});

$("button[type='button']").click(function () {
    $("#Signup").fadeToggle(1500);
    $("#login").fadeToggle(1400);
}); 