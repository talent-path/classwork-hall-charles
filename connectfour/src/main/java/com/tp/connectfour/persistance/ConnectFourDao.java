package com.tp.connectfour.persistance;

import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.models.ConnectFourGame;

import java.util.List;

public interface ConnectFourDao {

    ConnectFourGame getGameById(Integer gameId);
    List<ConnectFourGame> getAllGames();
    void updateGame(ConnectFourGame game);
    int startGame(Integer[][] board);
    void deleteGame(Integer gameId) throws InvalidGameIdException;

}
