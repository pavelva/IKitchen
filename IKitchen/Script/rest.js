var WEATHERURL = "http://api.worldweatheronline.com/free/v2/weather.ashx";
var key = "44cc220383a9679ba0d2e16f57655";

var WIKIURL = "http://en.wikipedia.org/w/api.php";

$(document).ready(function () {
    autocompleteSource = new google.maps.places.Autocomplete(
        (document.getElementById('autoCompleteInput')),
       {
           types: ['(cities)'],
           componentRestrictions: { country: 'il' }
       });

    google.maps.event.addListener(autocompleteSource, 'place_changed', function () {
        var location = document.getElementById('autoCompleteInput').value
        var locationText = "The Weather In " + location + " Is : ";
        var url = WEATHERURL + location;
        

        $.ajax({
            type: "GET",
            url: WEATHERURL,
            data: {
                q:location,
                key: key,
                format: "xml"
            },
            dataType: "xml",
            success: function(data){
                var temperature = $(data).find("hourly").find("tempC").text().substring(0, 2) + " C";
                $("#weatherPlace").text(locationText + temperature).show();
                $("#weatherImage").css("background-image", "url(" + $(data).find("current_condition").find("weatherIconUrl").text() + ")").show();
            },
            error: function (err) {
                $("#weatherPlace").text("There Was An Error. Please Try Again").show();
            }
        });

        var cityName = location.substring(0, location.indexOf(","));
        
        $.ajax({
            type: "GET",
            url: WIKIURL,
            data: {
                format: "json",
                action: "query",
                prop: "extracts",
                exintro: "",
                explaintext: "",
                redirects: "",
                titles: cityName,
                callback: "?"
            },
            dataType: "json",
            success: function(data){
                alert("OK");
                //var aboutCityObj = JSON.parse(data);
                //alert(aboutCityObj.query.pages.find("title"));
            },
            error: function (err) {
                alert("NOT OK");
                //$("#weatherPlace").text("There Was An Error. Please Try Again").show();
            }
        });

    });
});

