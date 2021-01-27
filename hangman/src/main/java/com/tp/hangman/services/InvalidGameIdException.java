package com.tp.hangman.services;

public class InvalidGameIdException extends Exception {

    public InvalidGameIdException(String msg) {
        super(msg);
    }

    public InvalidGameIdException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
