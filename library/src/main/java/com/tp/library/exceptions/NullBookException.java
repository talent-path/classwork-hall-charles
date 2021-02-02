package com.tp.library.exceptions;

public class NullBookException extends Exception {
    public NullBookException(String msg) {
        super(msg);
    }

    public NullBookException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
