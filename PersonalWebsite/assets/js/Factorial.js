$(function(){

	$("#factorialSubmit").click(function() {
		var factorial = +$("#factorialInput").val();
		if (isNaN(factorial) || factorial < 0 || factorial % 1) {
		    $("#factorialResult").text("The number has to be non-negative and an integer, please input again").removeClass().addClass("wrongInput");
		    $("#factorialInput").val("");
			return;
		}
		$("#factorialResult").text("The factorial of the number is: " + calculateFactorial(factorial)).removeClass().addClass("displayOutput");
	});
	
	$("#factorialReset").click(function() {
		myReset();
	});
	
})

function calculateFactorial(n){
	if	(n === 0){
		return 1;
	}
	else{
		return n*calculateFactorial(n-1);
	}
	return n;
}

function myReset() {
	$("#factorialInput").val("");
	$("#factorialResult").text("");
	return;
}