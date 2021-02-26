import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Position } from '../tictactoe/Position';

@Component({
  selector: 'app-tictactoe-square',
  templateUrl: './tictactoe-square.component.html',
  styleUrls: ['./tictactoe-square.component.css']
})

export class TictactoeSquareComponent implements OnInit {

  @Output() squareClickedEvent : EventEmitter<Position> = new EventEmitter<Position>();
  @Input() isX : number;
  @Input() row : number;
  @Input() col : number;

  imgSrc : string = "./assets/";

  constructor() { }

  ngOnInit(): void {

    if(this.isX === 0) {
      this.imgSrc = " ";
    }
    else {
      if(this.isX === 1) {
        this.imgSrc += "x.png";
      }
      else if (this.isX === -1){
        this.imgSrc += "o.png";
      }
    }

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
