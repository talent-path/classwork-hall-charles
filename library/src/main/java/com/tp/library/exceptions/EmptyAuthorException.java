package com.tp.library.exceptions;

public class EmptyAuthorException extends Exception {
    public EmptyAuthorException(String msg) {
        super(msg);
    }

    public EmptyAuthorException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
