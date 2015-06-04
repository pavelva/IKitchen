


function makeRegisterDetailes()
{
    $.when($("#registerContent").slideUp(700)).then(function () {
        $("#registerContent").hide();
        $("#signUpContent").slideDown(700);
    });
}

function forgotPasswordPopUp()
{
    $(".divFordialog").show();
    //$("body").css("background-color", "rgba(0,0,0,0.5)");
}

function closeDialog()
{
    $(".divFordialog").hide();
    //$("body").css("background-color", "");
}