package com.tp.hangman.services;

public class InvalidGuessException extends Exception{

    public InvalidGuessException(String msg) {
        super(msg);
    }

    public InvalidGuessException(String msg, Throwable innerException) {
        super(msg, innerException);
    }

}
