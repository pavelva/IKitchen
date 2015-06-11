function ajax(url, callback, error) {
    var xmlhttp;
    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari 
        xmlhttp = new XMLHttpRequest();
    } else {
        // code for IE6, IE5 
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            var status = xmlhttp.status;
            var t = xmlhttp;
            if (status == 200) {
                var response = xmlhttp.response;
                callback(response);
            }
            else{
                error(xmlhttp.status);
            }
        }

    };

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function addToCart(productId, callback) {
    var url = "Catalog.aspx?func=addToCart&pID=" + productId;
    ajax(url,
        function (data) {
            alert("המוצר התווסף לעגלה");
        },
        function (err) {
            if (err == 404) {
                var connect = confirm("יש להתחבר למערכת בכדי להתחיל לעשות קניות\nהאם ברצונך להתחבר כעת?");
                if (connect == true)
                    window.location = "loginRegister.aspx";
            }
            else if (err == 406) {
                alert("לא ניתן להזמין יותר מעשרה מוצרים מאותו הסוג");
            }
            else
                alert("בעיית תקשורת");
        });
}
