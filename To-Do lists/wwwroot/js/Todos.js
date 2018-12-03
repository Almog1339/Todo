/// <reference path="jquery-3.3.1.js" />


$("#loginsub").click(function () {

    var purl = "/api/Login";
    var gurl = "/api/GetTasks";

    var usersData = {
        UserName: $('#username').val(),
        Pass: $('#password').val()
    };

    $.post(purl, usersData).done(
        $('#login').fadeOut(),
        $('#Signup').fadeOut(),
        $('#container').show(500),
        function () {
            // dose not append...
            $('#navUsername').append('tesfdsjklfdjkljgkldsjfdsfdsfret54wrwegjklfkdlsfjdslfjds');
        });
    //// need to check this get function.....
    $.get(gurl, usersData.UserName).done(
        function () {
            for (var i = 0; i < 100; i++) {
                $('#tasks').append(data);
            };
        },
    );
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

