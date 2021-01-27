package com.tp.connectfour.models;

import java.util.ArrayList;
import java.util.List;

public class ConnectFourGame {

    private Integer gameId;
    private Integer[][] board;
    private List<Integer> occupiedSpots;

    public ConnectFourGame(Integer gameId, Integer[][] board) {
        this.gameId = gameId;
        this.board = board;
        occupiedSpots = new ArrayList<>();

        for(int i = 0; i < board.length; i++) {
            for(int j = 0; j < board[i].length; j++) {
                board[i][j] = 0;
            }
        }
    }

    public ConnectFourGame(ConnectFourGame that) {
        this.gameId = that.getGameId();
        this.board = that.board;
        this.occupiedSpots = new ArrayList<>();

        for(Integer toCopy : that.occupiedSpots) {
            this.occupiedSpots.add(toCopy);
        }

    }

    public Integer getGameId() {
        return gameId;
    }

    public Integer[][] getBoard() {
        return board;
    }

    public List<Integer> getOccupiedSpots() {
        return occupiedSpots;
    }

}
