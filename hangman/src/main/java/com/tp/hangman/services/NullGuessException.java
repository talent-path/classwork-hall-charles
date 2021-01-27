package com.tp.hangman.services;

public class NullGuessException extends Exception {

    public NullGuessException(String msg) {
        super(msg);
    }

    public NullGuessException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
