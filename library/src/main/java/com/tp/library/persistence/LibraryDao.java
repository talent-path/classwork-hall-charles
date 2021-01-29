package com.tp.library.persistence;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;

import java.util.List;

//CRUD: Create, read, update, delete
public interface LibraryDao {

    //CREATE
    int defineNewBook(String title, List<String> authors, Integer published) throws InvalidTitleException,
            InvalidPublishedYearException, NullTitleException, NullPublishedYearException, NullAuthorException, InvalidAuthorException;

    //READ
    List<Book> getAllBooks();
    List<Book> getBooksByTitle(String title) throws InvalidTitleException, NullTitleException;
    List<Book> getBooksByAuthor(List<String> author) throws InvalidAuthorException, NullAuthorException;
    List<Book> getBooksByPublishedYear(Integer year) throws InvalidPublishedYearException, NullPublishedYearException;
    Book getBookInfoById(Integer bookId) throws InvalidBookIdException, NullBookIdException;

    //UPDATE
    void updateBook(Integer bookId) throws InvalidBookIdException, NullBookIdException;

    //DELETE
    void removeBook(Integer bookId) throws InvalidBookIdException, NullBookIdException;
}
