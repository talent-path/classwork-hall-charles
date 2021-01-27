package com.tp.connectfour.persistance;

import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.models.ConnectFourGame;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
public class ConnectFourInMemDao implements ConnectFourDao{

    List<ConnectFourGame> allGames = new ArrayList<>();

    @Override
    public ConnectFourGame getGameById(Integer gameId) {
        ConnectFourGame toReturn = null;

        for(ConnectFourGame toCheck : allGames) {
            if(toCheck.getGameId().equals(gameId)) {
                toReturn = new ConnectFourGame(toCheck);
                break;
            }
        }

        return toReturn;
    }

    @Override
    public List<ConnectFourGame> getAllGames() {
        List<ConnectFourGame> copyList = new ArrayList<>();

        for(ConnectFourGame toCopy : allGames) {
            copyList.add(new ConnectFourGame(toCopy));
        }

        return copyList;
    }

    @Override
    public void updateGame(ConnectFourGame game) {

        for(int i = 0; i < allGames.size(); i++) {
            if(allGames.get(i).getGameId().equals(game.getGameId())) {
                allGames.set(i, new ConnectFourGame(game));
            }
        }

    }

    @Override
    public int startGame(Integer[][] board) {
        int id = 0;

        for(ConnectFourGame toCheck : allGames) {
            if(toCheck.getGameId() > id) {
                id = toCheck.getGameId();
            }
        }

        id++;
        ConnectFourGame toAdd = new ConnectFourGame(id, board);

        allGames.add(toAdd);

        return id;
    }

    @Override
    public void deleteGame(Integer gameId) throws InvalidGameIdException {
        int removeIndex = -1;

        for(int i = 0; i < allGames.size(); i++) {
            if(allGames.get(i).getGameId().equals(gameId)) {
                removeIndex = i;
                break;
            }
        }

        if(removeIndex != -1) {
            allGames.remove(removeIndex);
        } else {
            throw new InvalidGameIdException("Could not find game with id: " + gameId + " to delte.");
        }

    }
}
