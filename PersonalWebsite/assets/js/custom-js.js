$(function () {   
    $("#contactRequest").click(function (event) {
        if (document.getElementById("emailForm").value == "" || document.getElementById("fullNameForm").value == "" )
        {
            event.preventDefault();
            $("#fillForm").show(200);
        }     
    })
});