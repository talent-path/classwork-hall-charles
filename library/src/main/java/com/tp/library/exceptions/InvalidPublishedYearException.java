package com.tp.library.exceptions;

public class InvalidPublishedYearException extends Exception {
    public InvalidPublishedYearException(String msg) {
        super(msg);
    }

    public InvalidPublishedYearException(String msg, Throwable innerException) {
        super(msg, innerException);
    }
}
