$(document).ready(function () {
    $("#friendsList-input").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".user-card-body  ").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
}); 

    
    
    
    $(document).ready(function () {
        $("#searchInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $(".card").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    }); 


    
