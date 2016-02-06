$(function(){
    $("#longestWordSubmit").click(function () {
		var wordInput = $("#longestWordInput").val();
		var longest = "";
		var current = "";
		for (i = 0; i < wordInput.length; i++)
		{
			if  (isLetter(wordInput.charAt(i)) == true)
			{
				current += wordInput.charAt(i);
			}
			if (isLetter(wordInput.charAt(i)) == false || i == wordInput.length - 1)
			{
				if (current.length > longest.length)
				{
					longest = current;
				}
				current = "";
			}
		}
		$("#longestWordOutput").html("The longest word in the string is \'" + longest + "\'");
	})
	
	function isLetter(l) {
	  return l.toLowerCase() !== l.toUpperCase();
	}
})