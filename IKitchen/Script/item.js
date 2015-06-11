$(document).ready(function () {
    $("#btnProduct").click(function(){
        var p = $("#productId");
        var productId = $("#productId").val();
        addToCart(productId);
    });
})