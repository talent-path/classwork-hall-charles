package com.tp.connectfour.controller;

import com.tp.connectfour.exceptions.InvalidChoiceException;
import com.tp.connectfour.exceptions.InvalidGameIdException;
import com.tp.connectfour.exceptions.NullChoiceException;
import com.tp.connectfour.models.ConnectFourGame;
import com.tp.connectfour.services.ConnectFourService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ConnectFourController {

    //TODO: Autowire Service
    @Autowired
    ConnectFourService service;

    @GetMapping("/game")
    public List<ConnectFourGame> getAllGames() {
        return service.getAllGames();
    }

    @GetMapping("/game/{gameId}")
    public ConnectFourGame getGameById(@PathVariable Integer gameId) {
        return service.getGameById(gameId);
    }

    @PostMapping("/choice")
    public ResponseEntity chooseSpot(@RequestBody ChoiceRequest request) {
        //TODO fill with try/catch stuff
        ConnectFourGame toReturn = null;

        try{
            toReturn = service.makeChoice(request.getGameId(), request.getChoice());
        } catch (NullChoiceException | InvalidChoiceException | InvalidGameIdException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PostMapping("/begin")
    public ConnectFourGame startGame() {
        ConnectFourGame game = service.startGame();
        return game;
    }

    @DeleteMapping("/delete/{gameId}")
    public String deleteGame(@PathVariable Integer gameId) {
        //TODO fill with try/catch stuff
        throw new UnsupportedOperationException();
    }

}
