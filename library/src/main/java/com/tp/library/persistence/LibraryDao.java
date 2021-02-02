package com.tp.library.persistence;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;

import java.util.List;

//CRUD: Create, read, update, delete
public interface LibraryDao {

    //CREATE
    int defineNewBook(String title, List<String> authors, Integer published) throws NullTitleException,
            NullPublishedYearException, NullAuthorException, InvalidPublishedYearException;

    //READ
    List<Book> getAllBooks();
    List<Book> getBooksByTitle(String title) throws NullTitleException;
    List<Book> getBooksByAuthor(String author) throws NullAuthorException;
    List<Book> getBooksByPublishedYear(Integer year) throws NullPublishedYearException, InvalidPublishedYearException;
    Book getBookInfoById(Integer bookId) throws NullBookIdException;

    //UPDATE
    void updateLibrary(Book book) throws NullBookException;

    //DELETE
    void removeBook(Integer bookId) throws NullBookIdException;
}
