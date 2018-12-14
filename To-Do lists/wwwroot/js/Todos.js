/// <reference path="jquery-3.3.1.js" />

var tasks = [];

$("#BtnLogin").on("click", function () {

    var userData = {
        UserName: $('#username').val(),
        Pass: $('#password').val()
    };
    $.post("api/Login", userData).done(
        function (data) {
            if (data === -1) {
                    $("#Signup").animate({
                    height: 'toggle'
                    }),
                    $("#login").animate({
                    height: 'toggle'
                    });
            } else {
                $("#Signup").fadeOut();
                    $("#login").animate({
                        height: 'toggle'
                    });
                $('#containerToDo').animate({
                    height: 'toggle'
                });
                $('#subtitle').append(" " + userData.UserName);
                for (var i = 0; i < data.length; i++) {
                    $('#tasks').append("<li id='TodoTextContent' class='TodoTextContent'><span id=" + i +"><i class='fas fa-times'></i></span>" + data[i].content +"</li>");
                    tasks[i] = data[i];
                }
                $('#numofToDo').empty();
                $('#numofToDo').append(tasks.length);
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
                    $("#tasks").append("<li id='TodoTextContent' class='TodoTextContent'><span id="+tasks.last+"><i class='fas fa-times'></i></span>" + userData.TodoText + "</li>");
                    $("input[type = 'text']").empty();
                }
                $('#numofToDo').empty();
                $('#numofToDo').append(tasks.length +1);
            });
    }
});

$("#submitbtn").on("click",function (event) {

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
                alert("Success...Please try to login now..");
                $("#login").animate({
                    height: 'toggle'
                });
            }
        });
    event.stopPropagation();

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
            $('#numofToDo').empty();
            $('#numofToDo').append(tasks.length - 1);
        });
    event.stopPropagation();
});

$(".fa-plus").click(function () {
    $("input[type ='text']").animate({
        height: 'toggle'
    });
});

$("button[type='button']").click(function () {
        $("#Signup").animate({
            height: 'toggle'
        }),
        $("#login").animate({
            height: 'toggle'
        });
}); 
