$(function () {   
    $("#contactRequest").click(function (event) {
        if (document.getElementById("emailForm").value == "" || document.getElementById("fullNameForm").value == "") {
            event.preventDefault();
            $("#fillForm").show(200);
        }
    });          
});

//$(window).load(function() {
//    if (document.getElementById("formSent").innerHTML == "True"){
//        BootstrapDialog.alert('Thank you for submitting, your details have been sent! You will normally hear back from me within 24 hours.');
//    }          
//});
