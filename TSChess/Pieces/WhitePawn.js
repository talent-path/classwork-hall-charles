"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
exports.WhitePawn = void 0;
var ChessPiece_1 = require("./ChessPiece");
var Piece_1 = require("./Piece");
var WhitePawn = /** @class */ (function (_super) {
    __extends(WhitePawn, _super);
    function WhitePawn() {
        var _this = _super.call(this, Piece_1.PieceType.Pawn, true) || this;
        _this.generateMoves = function (moveOn, loc) {
            return [];
        };
        return _this;
    }
    return WhitePawn;
}(ChessPiece_1.ChessPiece));
exports.WhitePawn = WhitePawn;
