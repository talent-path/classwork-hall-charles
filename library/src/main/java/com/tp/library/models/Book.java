package com.tp.library.models;

import java.util.ArrayList;
import java.util.List;

public class Book {

    private Integer bookId;
    private String title;
    private List<String> authors;
    private Integer publishedYear;

    //Constructor for new book
    public Book(Integer bookId, String title, List<String> authors, Integer publishedYear) {
        this.bookId = bookId;
        this.title = title;
        this.authors = authors;
        this.publishedYear = publishedYear;
    }

    //Copy Constructor
    public Book(Book toCopy) {
        this.bookId = toCopy.bookId;
        this.title = toCopy.title;
        this.authors = new ArrayList<>();
        for(String copy : toCopy.authors) {
            this.authors.add(copy);
        }
        this.publishedYear = toCopy.publishedYear;
    }

    //Getters and Setters
    public Integer getBookId() {
        return bookId;
    }

    public void setBookId(Integer bookId) {
        this.bookId = bookId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public List<String> getAuthors() {
        return authors;
    }

    public void setAuthors(List<String> authors) {
        this.authors = authors;
    }

    public Integer getPublishedYear() {
        return publishedYear;
    }

    public void setPublishedYear(Integer publishedYear) {
        this.publishedYear = publishedYear;
    }

}
