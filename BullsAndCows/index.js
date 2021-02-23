function generateNumber() { //Generates 4 digit unique number
    let arr = [];
    while(arr.length < 4){
        let r = Math.floor(Math.random() * 10);
        if(arr.indexOf(r) === -1) {
            arr.push(r);
        }
    } 
    return arr.join("");
} 

let hiddenNumber = generateNumber();

function processGuess() {
    let userGuess = parseInt(document.getElementById("guess").value);
    let correctDigits = 0;

    const arrayOfDigitsGuess = Array.from(String(userGuess), Number);
    const arrayOfDigitsHidden = Array.from(String(hiddenNumber), Number);

    for(let i = 0; i < 4; i++) {        
        let pid = (i+1)+"text";
        let stringNumber = arrayOfDigitsGuess[i].toString(10);

        document.getElementById(pid).innerHTML = stringNumber;

        if(hasNumber(hiddenNumber, arrayOfDigitsGuess[i])) {
            if(arrayOfDigitsGuess[i] === arrayOfDigitsHidden[i]) {
                let strIndex = (i+1).toString(10);
                document.getElementById(strIndex).style.backgroundColor = "#00A300";
                correctDigits++;
            }
            else {
                let strIndex = (i+1).toString(10);
                document.getElementById(strIndex).style.backgroundColor = "#FFFF00";
            }
        }
        else {
            let strIndex = (i+1).toString(10);
            document.getElementById(strIndex).style.backgroundColor = "#FF0000";
        }

    }

    if(correctDigits === 4) {
        alert("Congrats you got it!");
    }

}

function hasNumber(num, digit){
    return num.toString().split("").some(function(item){
        return item == digit;
    }); 
}

function reset() {
    userGuess = '';
    hiddenNumber = generateNumber();
    document.getElementById('1').style.backgroundColor = "white";
    document.getElementById('2').style.backgroundColor = "white";
    document.getElementById('3').style.backgroundColor = "white";
    document.getElementById('4').style.backgroundColor = "white";

    document.getElementById('1text').innerHTML = "";
    document.getElementById('2text').innerHTML = "";
    document.getElementById('3text').innerHTML = "";
    document.getElementById('4text').innerHTML = "";

    document.getElementById("guess").value = "";
}
