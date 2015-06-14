


function makeRegisterDetailes()
{
    $.when($("#registerContent").slideUp(700)).then(function () {
        $("#registerContent").hide();
        $("#signUpContent").slideDown(700);
    });
}

function forgotPasswordPopUp()
{
    $(".forgotPassPopup").show();
}

function closeDialog()
{
    $(".forgotPassPopup").hide();
    document.getElementById("ContentPlaceHolder1_emailForgotPass").value = "";
    document.getElementById("ContentPlaceHolder1_answerForgatPass").value = "";
    document.getElementById("forgotPassErrorlabel").innerText = "";
}