

function makeRegisterDetailes()
{
    $.when($("#registerContent").slideUp(700)).then(function () {
        $("#registerContent").hide();
        $("#signUpContent").slideDown(700);
    });
}