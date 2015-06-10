$(document).ready(function () {
    $("#btnProduct").click(function(){
        var productId = ("#productId").innerHTML;
        var url = "Catalog.aspx?func=addToCart&pID=" + productId;

        ajax(url,
            function(data){
                alert("המוצר התווסף לעגלה");
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
})