/// <reference path="jquery-3.3.1.js" />


$("#loginsub").click(function () {

    var url = "/api/Login";

    var usersData = {
        UserName: $('#username').val(),
        Pass: $('#password').val()
    };

    $.post(url, usersData).done(
        $('#login').fadeOut(),
        function (data) {
            if (data === -1) {
                $('#Signup').show();
            } else {
                $('#Signup').fadeOut();
                console.log(data);
                $.get(url, function (data) {
                    if (data === -1) {
                        $('#Signup').show();
                    } else {
                        $('#nav').append(" " + usersData.UserName),
                            $('#container').show(500);
                        for (var i = 0; i < 50; i++) {
                            $('#tasks').append("<li><span><i class='far fa-trash-alt'></i></span>" + data + "</li>");
                        }
                    }
                });
            }
        });
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

