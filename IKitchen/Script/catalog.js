
$(document).ready(function () {
    initSearch();
});

function initButtons(){
    $(".catalogItem").click(function(e){
        if(e.toElement.className == 'btn')
            return;
        var productId = $(this).children(".productId")[0].innerHTML.replace(" ","");
        window.location = "Item.aspx?item=" + productId.toString();
    });

    $(".btn").click(function(e){
        var productId = $(this).parent().children(".productId")[0].innerHTML;
        addToCart(productId);
    });
}
function initSearch() {
    getCatalodItems();

    $(".catalogChk :checkbox").click(function (event) {
        var cur = event.toElement;
        var value = cur.nextSibling.textContent;

        var elementsApps = $(".catalogChk.app :checkbox");
        var apps = [];
        for (i in elementsApps) {
            if (elementsApps[i].type == "checkbox" && elementsApps[i].checked)
                apps.push(elementsApps[i].nextSibling.textContent);
        }


        var elementsCompansy = $(".catalogChk.company :checkbox");
        var companys = [];
        for (i in elementsCompansy) {
            if (elementsCompansy[i].type == "checkbox" && elementsCompansy[i].checked)
                companys.push(elementsCompansy[i].nextSibling.textContent);
        }


        getCatalodItems(apps, companys);
    });
}

function getCatalodItems(apps, companys) {
    $("body").css("cursor", "wait");
    $(".catalogChk :checkbox").prop('disabled', true);
    var url = "Catalog.aspx?func=getItems&" + (apps && apps.length>0? "apps=" + apps.toString(): "") +
        (apps && apps.length>0 && companys && companys.length>0 ? "&":"") +
        (companys && companys.length>0?"companys=" + companys.toString(): "");

    ajax(url,
        function (data) {
            $("#catalog").empty();
            $("#catalog").append(data);
            $("body").css("cursor", "default");
            $(".catalogChk :checkbox").prop('disabled', false);
            initButtons();
        },
        function () {
            $("body").css("cursor", "default");
            alert("בעיית תקשורת");
            $(".catalogChk :checkbox").prop('disabled', false);
        }
    );
}

function openPopUp() {
    $("#addNewItemPopUp").css("display", "block");
}


