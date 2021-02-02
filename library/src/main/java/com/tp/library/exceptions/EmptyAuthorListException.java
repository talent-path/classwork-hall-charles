package com.tp.library.exceptions;

public class EmptyAuthorListException extends Exception {
    public EmptyAuthorListException(String msg) {
        super(msg);
    }

    public EmptyAuthorListException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
