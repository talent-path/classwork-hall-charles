import { Component, OnInit } from '@angular/core';
import { TicTacToeBoard } from '../tictactoe/Board';
import { Position } from '../tictactoe/Position'


@Component({
  selector: 'app-tictactoe-board',
  templateUrl: './tictactoe-board.component.html',
  styleUrls: ['./tictactoe-board.component.css']
})

export class TictactoeBoardComponent implements OnInit {

  selectedSquare : Position = null;
  board : TicTacToeBoard = new TicTacToeBoard();

  constructor() { }

  ngOnInit(): void {
  }

  onSquareClicked(pos: Position) : void {
    if(this.board.gameOver === false) {
      this.board.placeMove(pos);
    }
    else {
      console.log("Cannot move, game over.");
    }
  }

  reset() {
    this.board.isXTurn = true;
    this.board.gameOver = false;

    for(let row = 0; row < 3; row++) {
      for(let col = 0; col < 3; col++) {
        this.board.allSquares[row][col] = 0;
      }
    }
  }

}
