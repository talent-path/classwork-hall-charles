package com.tp.library.exceptions;

public class NullPublishedYearException extends Exception {
    public NullPublishedYearException(String msg) {
        super(msg);
    }

    public NullPublishedYearException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
