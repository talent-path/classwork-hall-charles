package com.tp.hangman.services;

import com.tp.hangman.models.HangmanGame;
import com.tp.hangman.models.HangmanViewModel;
import com.tp.hangman.persistence.HangmanDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

//handles the logic for the game
@Component
public class HangmanService {

    @Autowired
    HangmanDao dao;

    public HangmanViewModel getGameById(Integer gameId) {
        HangmanGame game = dao.getGameById( gameId );
        return convertModel( game );
    }


    public HangmanViewModel makeGuess(Integer gameId, String guess) {
        if( guess.length() != 1){
            //TODO: make and throw a custom exception here
            return null;
        }

        if( gameId == null ){
            //TODO: make and throw a custom exception here
            return null;
        }

        HangmanGame game = dao.getGameById(gameId);

        //we'll assume here that the dao gives us back a null
        //if there's no matching game
        if( game == null) {
            return null;
        }

        if(game.getIncorrectGuesses() >= 5) {
            //TODO: make and throw a custom exception here (No more guesses)
            return convertModel(game);
        }
        else {
            game.getGuessedLetters().add(guess.charAt(0));
        }

        return convertModel(game);

    }

    private HangmanViewModel convertModel(HangmanGame game) {
        //TODO: generate the string with all the letters hidden that have not been guessed
        //and build the view model object (using the setters)
        HangmanViewModel viewModel = new HangmanViewModel();

        String partialWord = "";

        //Makes partialWord underscores of length of hiddenWord
        for(int i = 0; i < game.getHiddenWord().length(); i++) {
            partialWord = partialWord + "_";
        }

        //If no characters have been guessed, set partialWord to underscores
        if(game.getGuessedLetters().get(0) == null) {
            viewModel.setPartialWord(partialWord);
        }

        String realPartialWord = partialWord;
        //Else if there have been guesses...
        for(Character c : game.getGuessedLetters()) {
            //For each character c in guessedletters
            //Compare c with letter in hiddenWord
            //If they're the same, add letter in hiddenWord to partialWord
            //Else, compare next c to letter
            if (game.getHiddenWord().contains(c+"")) {
                List<Integer> indexList = new ArrayList<>();

                //Adds all instances of c in word to index list
                for (int index = game.getHiddenWord().indexOf(c);
                     index >= 0;
                     index = game.getHiddenWord().indexOf(c, index + 1))
                {
                    indexList.add(index);
                }

                //Using the indexes in indexList, replace chars in word
                for(Integer i : indexList) {
                    realPartialWord = realPartialWord.substring(0,i) + c + realPartialWord.substring(i+1);
                }
            }
            else {
                game.setIncorrectGuesses(game.getIncorrectGuesses()+1);
            }
        }

        //Set the guessedLetters and partialWord
        viewModel.setGuessedLetters(game.getGuessedLetters());
        viewModel.setPartialWord(realPartialWord);
        viewModel.setIncorrectGuesses(game.getIncorrectGuesses());

        return viewModel;

    }
}
