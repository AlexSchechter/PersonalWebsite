$(function(){
	
	$("#launch").click(function(){
		
		var firstNumber = +$("#firstFBInput").val();
		var secondNumber = +$("#secondFBInput").val();
		
		$("#outputTable").empty();
		$('table').removeClass();
		
		
		if (firstNumber < 1 || secondNumber < 1 || firstNumber > 100 || secondNumber > 100 || firstNumber % 1 || secondNumber % 1 )
		{	
		    myReset();
		    $("#alertUser").text("Both numbers have to be integers between 1 and 100, please input again");
			return;
		};
		
		$("#alertUser").text("");
		$(myHighlight).addClass('tableStyleFB');
	
		for (i = 1; i <= 100; i++) {			
			
			if ((i-1)%10 === 0) {
				$('#outputTable').append("<tr>");
			};
			
			if (i%firstNumber === 0) {
				if (i%secondNumber === 0) {
					$('#outputTable').append("<td class='col-sm-1 fizzBuzz'>FizzBuzz</td>");
				} else {
					$('#outputTable').append("<td class='col-sm-1 fizz'>Fizz</td>");
				}
			} else if (i%secondNumber === 0) {
				$('#outputTable').append("<td class='col-sm-1 buzz'>Buzz</td>");
			} else {
				$('#outputTable').append("<td class='col-sm-1 myNumber'>" + i + "</td>");
			};
			
			if (i%10 === 0) {
				$('#outputTable').append("</tr>");
			};
		};
			
	});
			
	$("#resetting").click(function(){
		myReset();
	});
		
	function myReset() {
	$("#firstFBInput, #secondFBInput").val(''); 
	$("#outputTable").empty();
	$('table').removeClass();
	$("#alertUser").text("");
	} 
});