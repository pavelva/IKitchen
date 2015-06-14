$(document).ready(function(){
    initButtons();

    if($(".defaultCatalogItem").length == 0)
        $("#ContentPlaceHolder1_defaultList").hide();

    if($(".buysCatalogItem").length == 0)
        $("#ContentPlaceHolder1_buys").hide();

    if($(".categorysCatalogItem").length == 0)
        $("#ContentPlaceHolder1_categorys").hide();

    if($(".defaultCatalogItem").length == 0 && $(".buysCatalogItem").length == 0 &&  $(".categorysCatalogItem").length == 0)
    $("#content").append("לא נמצאו המלצות המתאימות לך");
});
