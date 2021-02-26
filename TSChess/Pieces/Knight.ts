import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class Knight extends ChessPiece {

    constructor( isWhite : boolean ){
        super( PieceType.Knight, isWhite );
    }

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
    (moveOn: Board, loc: Position)  => {
    
        return [];
    }
    
}