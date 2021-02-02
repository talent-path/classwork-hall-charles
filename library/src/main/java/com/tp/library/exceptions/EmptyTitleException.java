package com.tp.library.exceptions;

public class EmptyTitleException extends Exception {
    public EmptyTitleException(String msg) {
        super(msg);
    }

    public EmptyTitleException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
