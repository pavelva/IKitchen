var WEATHERURL = "http://api.worldweatheronline.com/free/v2/weather.ashx";
var key = "44cc220383a9679ba0d2e16f57655";
var WIKIURL = "http://en.wikipedia.org/w/api.php";
var cityName = "";

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
            success: function (data) {
                $("#aboutCity").hide();
                var temperature = $(data).find("hourly").find("tempC").text().substring(0, 2) + " C";
                $("#weatherPlace").text(locationText + temperature).show();
                $("#weatherImage").css("background-image", "url(" + $(data).find("current_condition").find("weatherIconUrl").text() + ")").show();
                if(location.indexOf(",") != -1){
                    cityName = location.substring(0, location.indexOf(","));
                }
                else{
                    cityName = location;
                }
                $("#learnBtn").show();
                $("#cityLearn").text("If You Want To Learn More About " + cityName + " Press ").show();
            },
            error: function (err) {
                $("#weatherPlace").text("There Was An Error. Please Try Again").show();
            }
        });
        $('#learnBtn').click(function () {
            $('html, body').animate({
                scrollTop: $("#cityLearn").offset().top
            }, 2000);
            $.ajax({
                type: "GET",
                dataType: "json",
                url: WIKIURL + "?format=json&action=query&prop=extracts&exintro=&explaintext=&redirects=&titles=" + cityName + "&callback=?",

                success: function (result) {
                    jsonObj = result.query.pages;
                    var pageNum;
                    for (page in jsonObj) {
                        pageNum = page
                        break;
                    }
                    $("#aboutCity").text(jsonObj[pageNum].extract).show();
                },
                error: function (err) {
                    $("#aboutCity").text("There Was An Error. Please Try Again").show();
                }
            });

        });
    });
});

function showInfo() {
}