var WEATHERURL = "http://api.worldweatheronline.com/free/v2/weather.ashx";
var key = "44cc220383a9679ba0d2e16f57655";
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
                alert(123);
            }
        });
    });
});

