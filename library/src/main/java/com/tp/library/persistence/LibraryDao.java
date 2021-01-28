package com.tp.library.persistence;

import com.tp.library.models.Book;

import java.util.List;

//CRUD: Create, read, update, delete
public interface LibraryDao {

    //CREATE
    int defineNewBook(String title, List<String> authors, Integer published);

    //READ
    List<Book> getAllBooks();
    List<Book> getBooksByTitle(String title);
    List<Book> getBooksByAuthor(String author);
    List<Book> getBooksByPublishedYear(Integer year);
    Book getBookInfoById(Integer bookId);

    //UPDATE
    void updateBook(Integer bookId);

    //DELETE
    void removeBook(Integer bookId);
}
