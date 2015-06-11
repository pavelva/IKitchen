$(document).ready(function(){
    initButtons();
});

function initButtons(){
    $(".catalogItem").click(function(e){
        if (e.toElement.className != 'catalogItem')
            return;
        var productId = $(this).children(".productId")[0].innerHTML.replace(" ","");
        window.location = "Item.aspx?item=" + productId.toString();
    });

    $(".btnProduct").click(function(){
        var productId = $(this).parent().children(".productId")[0].innerHTML;
        addToCart(productId);

    });
}