package com.tp.hangman.models;

import ch.qos.logback.core.util.InvocationGate;

import java.util.ArrayList;
import java.util.List;

public class HangmanGame {
    Integer gameId;
    String hiddenWord;
    List<Character> guessedLetters;
    Integer incorrectGuesses;

    //constructor for a new game
    public HangmanGame( Integer gameId, String hiddenWord ){
        this.gameId = gameId;
        this.hiddenWord = hiddenWord;
        guessedLetters = new ArrayList<>();
        incorrectGuesses = 0;
    }

    //constructor for an existing game (will have more use after we have databases)
    public HangmanGame(Integer gameId, String hiddenWord, List<Character> guessedLetters){
        this.gameId = gameId;
        this.hiddenWord = hiddenWord;
        this.guessedLetters = guessedLetters;
        incorrectGuesses = 0;
    }


    public Integer getGameId() {
        return gameId;
    }

    public String getHiddenWord() {
        return hiddenWord;
    }

    public List<Character> getGuessedLetters() {
        return guessedLetters;
    }

    public Integer getIncorrectGuesses() {
        return incorrectGuesses;
    }

    public void setIncorrectGuesses(Integer incorrectGuesses) { this.incorrectGuesses = incorrectGuesses; }
}
