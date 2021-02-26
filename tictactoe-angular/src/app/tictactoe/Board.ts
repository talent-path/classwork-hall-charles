import { Position } from './Position';

export class TicTacToeBoard {

    isXTurn : boolean;
    allSquares : number [][];
    gameOver : boolean;
    xWins : number;
    oWins : number;

    constructor(copyFrom?: TicTacToeBoard, turn?: boolean, gameOver?: boolean) {
        if(copyFrom) {

            this.allSquares = [];
            this.isXTurn = turn;
            this.gameOver = gameOver;

        }
        else {

            this.allSquares = [];
            this.isXTurn = true;
            this.gameOver = false;
            this.xWins = 0;
            this.oWins = 0;

            for(let row = 0; row < 3; row++) {
                this.allSquares[row] = [];
                for(let col = 0; col < 3; col++) {
                        this.allSquares[row][col] = 0;
                }
            }
        }
    }
    
    placeMove(toPlace : Position) : void {

        let won : boolean = false;

        if(this.isXTurn) {
            this.allSquares[toPlace.row][toPlace.col] = 1;
            won = this.checkWin(this.allSquares, this.isXTurn);
        }
        else {
            this.allSquares[toPlace.row][toPlace.col] = -1;
            won = this.checkWin(this.allSquares, this.isXTurn);
        }

        if(won === true) {
            this.gameOver = true;
            let player : string = "";
            if(this.isXTurn) {
                player = "X";
                this.xWins++;
            }
            else {
                player = "O";
                this.oWins++;
            }

            console.log("Player " + player + " wins!");
        
        }

        this.isXTurn = !this.isXTurn;

    }

    checkWin(board: number[][], isX: boolean) : boolean {
        
        let won : boolean = false;
        let player : number;

        if(isX) {
            player = 1;
        }
        else {
            player = -1;
        }

        for(let i = 0; i < 3; i++) {
            if(board[i][0] === player && board[i][1] === player && board[i][2] === player) {//Rows
                won = true;
            }

            if(board[0][i] === player && board[1][i] === player && board[2][i] === player) {//Cols
                won = true;
            }

            if((board[0][0] === player && board[1][1] === player && board[2][2] == player)//Diagonal
                || (board[0][2] === player && board[1][1] === player && board[2][0] === player)) {
                won = true
            }
        }

        return won;
    }

}