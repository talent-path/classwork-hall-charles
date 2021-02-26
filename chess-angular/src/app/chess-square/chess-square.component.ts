import { Component, Input, OnInit } from '@angular/core';
import { Piece, PieceType} from '../chess/Pieces/Piece';
import { Bishop } from '../chess/Pieces/Bishop';
import {Output, EventEmitter} from '@angular/core';
import {Position} from '../chess/Position'
@Component({
  selector: 'app-chess-square',
  templateUrl: './chess-square.component.html',
  styleUrls: ['./chess-square.component.css']
})

export class ChessSquareComponent implements OnInit {

  @Output() squareClickedEvent : EventEmitter<Position> = new EventEmitter<Position>();
  @Input() squarePiece: Piece = new Bishop(true);
  imgSrc : string = "./assets/";
  @Input() row : number = 0;
  @Input() col : number = 7;
  isLightSquare : boolean = true;

  constructor() {}

  ngOnInit(): void {

    if(this.squarePiece === null) {
      this.imgSrc = " ";
    }
    else {
      this.imgSrc += this.squarePiece.isWhite ? "w" : "b";
      switch(this.squarePiece.kind) {
        case PieceType.Bishop: {
          this.imgSrc += "B";
          break;
        }
        case PieceType.King: {
          this.imgSrc += "K";
          break;
        }
        case PieceType.Queen: {
          this.imgSrc += "Q";
          break;
        }
        case PieceType.Knight: {
          this.imgSrc += "N";
          break;
        }
        case PieceType.Pawn: {
          this.imgSrc += "P";
          break;
        }
        case PieceType.Rook: {
          this.imgSrc += "R";
          break;
        }

      }
      this.imgSrc += ".png";
    }

    this.isLightSquare = (this.row + this.col) % 2 === 0;
  }
  
  squareClicked() : void {
    this.squareClickedEvent.emit(
      {
        row: this.row,
        col: this.col
      }
    );
  }

}
