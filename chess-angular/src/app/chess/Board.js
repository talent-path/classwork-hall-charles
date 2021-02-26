"use strict";
var __spreadArray = (this && this.__spreadArray) || function (to, from) {
    for (var i = 0, il = from.length, j = to.length; i < il; i++, j++)
        to[j] = from[i];
    return to;
};
exports.__esModule = true;
var King_1 = require("./Pieces/King");
var Piece_1 = require("./Pieces/Piece");
var Queen_1 = require("./Pieces/Queen");
var Rook_1 = require("./Pieces/Rook");
var ChessBoard = /** @class */ (function () {
    function ChessBoard(copyFrom, turn) {
        var _this = this;
        this.buildFrom = function (toCopy) {
            // [a, b, c]
            // [[a, b, c]]
            _this.fiftyMoveCount = toCopy.fiftyMoveCount;
            _this.wKingSideCastle = toCopy.wKingSideCastle;
            _this.bKingSideCastle = toCopy.bKingSideCastle;
            _this.wQueenSideCastle = toCopy.wQueenSideCastle;
            _this.bQueenSideCastle = toCopy.bQueenSideCastle;
            for (var i = 0; i < toCopy.allSquares.length; i++) {
                _this.allSquares.push(__spreadArray([], toCopy.allSquares[i]));
            }
        };
        this.makeMove = function (toMake) {
            //TODO: enpassant stuff
            //TODO: 50 move rule stuff
            var nextBoard = new ChessBoard(_this, !_this.isWhiteTurn);
            var oldPiece = nextBoard.allSquares[toMake.from.row][toMake.from.col];
            // 50 move rule
            if (nextBoard.pieceAt(toMake.to) !== null) {
                nextBoard.fiftyMoveCount = 0;
            }
            else if (oldPiece.kind !== Piece_1.PieceType.Pawn) {
                nextBoard.fiftyMoveCount++;
            }
            else {
                nextBoard.fiftyMoveCount = 0;
            }
            // castling rule
            if (oldPiece && (oldPiece.kind === Piece_1.PieceType.King || oldPiece.kind === Piece_1.PieceType.Rook)) {
                if (oldPiece.isWhite) {
                    if (oldPiece.kind === Piece_1.PieceType.King) {
                        nextBoard.wKingSideCastle = false;
                        nextBoard.wQueenSideCastle = false;
                    }
                    else if (toMake.from.col === 0) {
                        nextBoard.wQueenSideCastle = false;
                    }
                    else if (toMake.from.col === 7) {
                        nextBoard.wKingSideCastle = false;
                    }
                }
                else {
                    if (oldPiece.kind === Piece_1.PieceType.King) {
                        nextBoard.bKingSideCastle = false;
                        nextBoard.bQueenSideCastle = false;
                    }
                    else if (toMake.from.col === 0) {
                        nextBoard.bQueenSideCastle = false;
                    }
                    else if (toMake.from.col === 7) {
                        nextBoard.bKingSideCastle = false;
                    }
                }
            }
            nextBoard.allSquares[toMake.from.row][toMake.from.col] = null;
            nextBoard.allSquares[toMake.to.row][toMake.to.col] = oldPiece;
            return nextBoard;
        };
        if (copyFrom) {
            this.allSquares = [];
            this.fiftyMoveCount = 0;
            this.wKingSideCastle = true;
            this.bKingSideCastle = true;
            this.wQueenSideCastle = true;
            this.bQueenSideCastle = true;
            this.buildFrom(copyFrom);
            this.isWhiteTurn = turn;
        }
        else {
            this.allSquares = [];
            this.isWhiteTurn = true;
            this.wKingSideCastle = true;
            this.bKingSideCastle = true;
            this.wQueenSideCastle = true;
            this.bQueenSideCastle = true;
            this.fiftyMoveCount = 0;
            for (var row = 0; row < 8; row++) {
                this.allSquares[row] = [];
                for (var col = 0; col < 8; col++) {
                    // if (row === 1 || row === 6) {
                    //     this.allSquares[row][col] = row === 1 ? new WhitePawn() : new BlackPawn();
                    // }
                    if ((row === 0 || row === 7) && (col === 0 || col === 7)) {
                        this.allSquares[row][col] = new Rook_1.Rook(row === 0);
                    }
                    // if ((row === 0 || row === 7) && (col === 1 || col === 6)) {
                    //     this.allSquares[row][col] = new Knight(row === 0);
                    // }
                    // if ((row === 0 || row === 7) && (col === 2 || col === 5)) {
                    //     this.allSquares[row][col] = new Bishop(row === 0);
                    // }
                    if (col === 3 && (row === 0 || row === 7)) {
                        this.allSquares[row][col] = new Queen_1.Queen(row === 0);
                    }
                    if (col === 4 && (row === 0 || row === 7)) {
                        this.allSquares[row][col] = new King_1.King(row === 0);
                    }
                    if (!this.allSquares[row][col]) {
                        this.allSquares[row][col] = null;
                    }
                }
            }
        }
    }
    // enPassantCaptureLoc?: Position;
    //  rnbqkbnr        7
    //  pppppppp        6
    //  ........        5
    //  ........        4
    //  ........        3
    //  ........        2
    //  PPPPPPPP        1
    //  RNBQKBNR        0
    //  01234567
    ChessBoard.prototype.pieceAt = function (loc) {
        return this.allSquares[loc.row][loc.col];
    };
    ChessBoard.prototype.generateMoves = function () {
        var allMoves = [];
        for (var row = 0; row < 8; row++) {
            for (var col = 0; col < 8; col++) {
                if (this.allSquares[row][col] && this.allSquares[row][col].isWhite === this.isWhiteTurn) {
                    allMoves.push.apply(allMoves, this.allSquares[row][col].generateMoves(this, { row: row, col: col }));
                }
            }
        }
        return allMoves;
    };
    return ChessBoard;
}());
console.log("attempting to create a board");
var testBoard = new ChessBoard();
console.log("done creating a board:");
// first white turn
console.log("BOARD", testBoard.allSquares);
console.log("White King Castle", testBoard.wKingSideCastle);
console.log("Black King Castle", testBoard.bKingSideCastle);
console.log("White Queen Castle", testBoard.wQueenSideCastle);
console.log("Black Queen Castle", testBoard.bQueenSideCastle);
console.log("MOVES", testBoard.generateMoves());
testBoard = testBoard.makeMove({ from: { row: 0, col: 0 }, to: { row: 1, col: 0 } });
console.log("BOARD", testBoard.allSquares);
console.log("White King Castle", testBoard.wKingSideCastle);
console.log("Black King Castle", testBoard.bKingSideCastle);
console.log("White Queen Castle", testBoard.wQueenSideCastle);
console.log("Black Queen Castle", testBoard.bQueenSideCastle);
console.log("MOVES", testBoard.generateMoves());
