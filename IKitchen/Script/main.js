$(document).ready(function(){
    initButtons();
});

function initButtons(){
    $(".catalogItem").click(function(e){
        if(e.toElement.className == 'btnProduct')
            return;
        var productId = $(this).children(".productId")[0].innerHTML.replace(" ","");
        window.location = "Item.aspx?item=" + productId.toString();
    });

    $(".btnProduct").click(function(){
        var productId = $(this).parent().children(".productId")[0].innerHTML;
        var url = "Catalog.aspx?func=addToCart&pID=" + productId;
        alert(1);
        ajax(url,
            function(data){
                $(this).css("background", "#307bd4");
            },
            function(err){
                if(err = 404) {
                    var connect = confirm("יש להתחבר למערכת בכדי להתחיל לעשות קניות\nהאם ברצונך להתחבר כעת?");
                    if(connect == true)
                        window.location = "loginRegister.aspx";
                }
                else
                    alert("בעיית תקשורת");
            });
    });

    $(".catalogItem").click(function(){
        var productId = $(this).children(".productId")[0].innerHTML.replace(" ","");
        window.location = "Item.aspx?item=" + productId.toString();
    });
}