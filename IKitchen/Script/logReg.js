


function makeRegisterDetailes()
{
    $.when($("#registerContent").slideUp(700)).then(function () {
        $("#registerContent").hide();
        $("#signUpContent").slideDown(700);
    });
}

function forgotPasswordPopUp()
{
    $("#forgotPasswordDialog").show();
    $("body").css("background-color", "rgba(0,0,0,0.5)");
}

function closeDialog()
{
    $("#forgotPasswordDialog").hide();
    $("body").css("background-color", "");
}