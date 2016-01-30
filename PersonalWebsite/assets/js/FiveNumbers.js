$(function(){
	$("#fiveNumbersSubmit").click(function() {
		var firstNumber = +$("#firstInput").val();
		var secondNumber = +$("#secondInput").val();
		var thirdNumber = +$("#thirdInput").val();
		var fourthNumber = +$("#fourthInput").val();
		var fifthNumber = +$("#fifthInput").val();

		smallestNumber = Math.min(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);
		largestNumber = Math.max(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);
		mySum = firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber;
		myMean = mySum / 5;
		myProduct = firstNumber * secondNumber * thirdNumber * fourthNumber * fifthNumber;
		
		$("#smallest").text("The smallest number is: " + smallestNumber);
		$("#largest").text("The largest number is: " + largestNumber);
		$("#mean").text("The mean of the numbers is: " + myMean);
		$("#sum").text("The sum of the numbers is: " + mySum);
		$("#product").text("The product of the numbers is: " + myProduct);
	});

	$("#fiveNumbersReset").click(function() {
		$("#firstInput").val(0);
		$("#secondInput").val(0);
		$("#thirdInput").val(0);
		$("#fourthInput").val(0);
		$("#fifthInput").val(0);
		
		$("#smallest").text("");
		$("#largest").text("");
		$("#mean").text("");
		$("#sum").text("");
		$("#product").text("");			
	});
})