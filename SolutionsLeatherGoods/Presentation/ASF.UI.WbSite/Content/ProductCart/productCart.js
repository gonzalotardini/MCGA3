$(document).ready(function () {
    $("#carticon").click(function () {
        $("#cartContent").slideToggle("2000");
    });

    $("#btn").click(function () {

        var title = $("#title")[0].textContent;

        $("#lista").append(title);
      
        
        
    });


    
});
