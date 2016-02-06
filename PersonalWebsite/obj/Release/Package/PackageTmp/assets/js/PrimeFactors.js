$(function () {

    $("#primeFactorsSubmit").click(function () {
        var  myNumber = +$("#primeFactorsInput").val();
        if ( isNaN(myNumber) || myNumber < 2 || myNumber%1 ) {
            //alert("The number has to be an integer greater or equal to 2, please input again")
            $("#primeFactorsResult").text("The number has to be an integer greater or equal to 2, please input again").removeClass().addClass("wrongInput");
            $("#primeFactorsInput").val("");
            return;
        }
        $("#primeFactorsResult").text("The prime factors are: " + primeFactors(myNumber)).removeClass().addClass("displayOutput");
    });

    $("#primeFactorsReset").click(function () {
        myReset();
    });

})

function primeFactors(n) {
    var allPrimeFactors = [];
    var prime;
    do {
        prime = smallestPrimeFactor(n);
        allPrimeFactors.push(prime);
        n /= prime;
    }
    while (n != 1);
    return allPrimeFactors;
}

function smallestPrimeFactor(n) {
        for (var i = 2; i <= n ; i++) {
            if (n % i == 0) {
                return i;
            }
        }
}

function myReset() {
    $("#primeFactorsInput").val("");
    $("#primeFactorsResult").text("");
    return;
}