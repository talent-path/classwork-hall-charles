package com.tp.connectfour.services;

import com.tp.connectfour.exceptions.InvalidChoiceException;
import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.exceptions.NullChoiceException;
import com.tp.connectfour.models.ConnectFourGame;
import com.tp.connectfour.persistance.ConnectFourDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ConnectFourService {

    @Autowired
    ConnectFourDao dao;

    public List<ConnectFourGame> getAllGames() {
        List<ConnectFourGame> allGames = dao.getAllGames();
        return allGames;
    }

    public ConnectFourGame getGameById(Integer gameId) {
        ConnectFourGame game = dao.getGameById(gameId);
        return game;
    }

    public ConnectFourGame startGame() {
        Integer[][] newBoard = new Integer[6][7];
        int newGameId = dao.startGame(newBoard);

        return this.getGameById(newGameId);
    }

    public ConnectFourGame makeChoice(Integer gameId, Integer choice)
            throws NullChoiceException, InvalidChoiceException, InvalidGameIdException {
        if(choice == null)
            throw new NullChoiceException("Null choice exception.");
        if(choice < 0 || choice > 6)
            throw new InvalidChoiceException("Not a valid column choice.");
        if(gameId == null)
            throw new InvalidGameIdException("Missing game id.");

        ConnectFourGame game = dao.getGameById(gameId);
        //If user makes valid choice
        //Piece goes down until it reaches another piece OR row 5 (max row)
        // -1: player 1 | 0: empty | 1: player 2
        for(int row = 0; row < game.getBoard().length; row++) {
            if(game.getBoard()[row][choice] == 0) {//If the spot is empty
                //Check next row to see if it is also empty
                //Else place checker
                continue;
            }
            else if(game.getBoard()[row][choice] != 0) {
                //TODO figure out determining which player is playing
                game.getBoard()[row-1][choice] = 1;
                break;
            }
        }

        //Add choice to occupiedSpots list
        game.getOccupiedSpots().add(choice);
        //Update allGames list with current game state
        dao.updateGame(game);

        return game;
    }
}
