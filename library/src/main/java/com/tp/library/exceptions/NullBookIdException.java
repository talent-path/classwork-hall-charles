package com.tp.library.exceptions;

public class NullBookIdException extends Exception {
    public NullBookIdException(String msg) {
        super(msg);
    }

    public NullBookIdException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
