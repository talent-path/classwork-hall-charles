package com.tp.library.controllers;

import java.util.List;

public class UpdateAuthorRequest {

    Integer bookId;
    List<String> newAuthors;

    public Integer getBookId() {
        return bookId;
    }

    public void setBookId(Integer bookId) {
        this.bookId = bookId;
    }

    public List<String> getNewAuthors() {
        return newAuthors;
    }

    public void setNewAuthors(List<String> newAuthors) {
        this.newAuthors = newAuthors;
    }

}
