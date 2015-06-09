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