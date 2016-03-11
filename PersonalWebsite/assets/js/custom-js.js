$(function () {   
    $("#contactRequest").click(function (event) {
        BootstrapDialog.alert('Thank you for submitting, your details have been sent! You will normally hear back from me within 24 hours.');
        if (document.getElementById("emailForm").value == "" || document.getElementById("fullNameForm").value == "" )
        {
            event.preventDefault();
            $("#fillForm").show(200);
        }
        else
        {
            BootstrapDialog.alert('Thank you for submitting, your details have been sent! You will normally hear back from me within 24 hours.');
        }
    })
    
   
});