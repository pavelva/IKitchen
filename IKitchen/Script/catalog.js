$(document).ready(function () {
    $(".catalogChk :checkbox").click(function(event){
        var cur = event.toElement;
        var value = cur.nextSibling.textContent;

        var elementsApps = $(".catalogChk.app :checkbox");
        var apps = [];
        for(i in elementsApps){
            if(elementsApps[i].type == "checkbox" && elementsApps[i].checked)
                apps.push(elementsApps[i].nextSibling.textContent);
        }


        var elementsCompansy = $(".catalogChk.company :checkbox");
        var companys = [];
        for(i in elementsCompansy){
            if(elementsCompansy[i].type == "checkbox" && elementsCompansy[i].checked)
                companys.push(elementsCompansy[i].nextSibling.textContent);
        }

        $("body").css("cursor", "wait");

        $.ajax({
            type: "GET",
            url: "Catalog.aspx?func=getItems&" + (apps.length>0? "apps=" + apps.toString(): "") + (companys.length>0?"&companys=" + companys.toString(): ""),
            success: function(data){
                $("#catalog").empty();
                $("#catalog").append(data);
                $("body").css("cursor", "default");
            },
            error: function(err) {
                $("body").css("cursor", "default");
                alert("A connection error has occurred");
            }
        });
    });

});

function run() {
    
    $.ajax({
        type: "GET",
        url: "Catalog.aspx?id=1",
        success: function(data){
            alert(data);
        },
        error: function(err) {
            alert(2);
        }
    });
}


