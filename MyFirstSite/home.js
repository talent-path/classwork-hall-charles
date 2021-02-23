alert("Hello!!");

function toggleClick() {

    let elementToToggle = document.getElementById("toggleText")

    if(elementToToggle.style.display === "none") {
        elementToToggle.style.display = "block";
    } else {
        elementToToggle.style.display = "none";
    }
}

let gameBoard;

function init() {
    gameBoard = 
    [1, 1, 1, 
    '', '', '', 
    '', '', ''];
}

function checkRows(board) {
    if(board[0] === board[1] === board[2]){
        return true;
    }
    if(board[3] === board[4] === board[5]) {
        return true;
    }
    if(board[6] === board[7] === board[8]) {
        return true;
    }
}

function checkColumns(board) {
    if(board[0] === board[3] === board[6]){
        return true;
    }
    if(board[1] === board[4] === board[7]) {
        return true;
    }
    if(board[2] === board[5] === board[8]) {
        return true;
    }
}

function checkDiagonal(board) {
    if(board[0] === board[4] === board[8]){
        return true;
    }
    if(board[2] === board[4] === board[6]) {
        return true;
    }
}

console.log()