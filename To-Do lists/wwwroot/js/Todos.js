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
                $.get(url, usersData).done(
                    function () {
                        for (var i = 0; i < 100; i++) {
                            $('#tasks').append("<li><span><i class='far fa - trash - alt'></i></span>" + tasks + "</li>");
                        }
                    });
                $('#Signup').fadeOut(),
                    $('#nav').append(usersData.UserName),
                    $('#container').show(500)
            };
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

