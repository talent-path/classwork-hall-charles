package com.tp.library.controllers;

public class UpdatePublishRequest {

    Integer bookId;
    Integer newPublishedYear;

    public Integer getBookId() {
        return bookId;
    }

    public void setBookId(Integer bookId) {
        this.bookId = bookId;
    }

    public Integer getNewPublishedYear() {
        return newPublishedYear;
    }

    public void setNewPublishedYear(Integer newPublishedYear) {
        this.newPublishedYear = newPublishedYear;
    }

}
