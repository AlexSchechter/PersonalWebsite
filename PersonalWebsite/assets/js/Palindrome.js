$(function(){
	
	$("#submitPalindrome").click(function(){
		
		$('#myOutput').empty();	
		$('body').removeClass();
		
		var myWord = $('#wordInput').val();
		var wordLength = myWord.length;
		var isPalindrome = true;
		
		$('#wordOutput').text('');
		
		if (wordLength === 0) {
			alert("Please input a word");
			return;
		}
	
		for (i = 1; i < (Math.floor(wordLength/2) + 1); i++) {
			
			if (myWord[i-1] !== myWord[wordLength-i]) {
				isPalindrome = false;
				{break;} ;
			}
		}
	
		if (isPalindrome === true) {
			$('#wordOutput').append(myWord + " is a Palindrome");
		} 
		else {
			$('#wordOutput').append(myWord + " is NOT a Palindrome");
		}
	
	})
	
	$("#resetPalindrome").click(function(){
		$('#wordInput').val([]);
		$('#wordOutput').empty();		
	})
		
});