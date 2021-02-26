import { Component, OnInit } from '@angular/core';
import { TicTacToeBoard } from '../tictactoe/Board'

@Component({
  selector: 'app-tictactoe-page',
  templateUrl: './tictactoe-page.component.html',
  styleUrls: ['./tictactoe-page.component.css']
})
export class TictactoePageComponent implements OnInit {

  board : TicTacToeBoard = new TicTacToeBoard();

  constructor() { }

  ngOnInit(): void {
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
