package com.tp.library.services;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;
import com.tp.library.persistence.LibraryDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class LibraryService {

    @Autowired
    LibraryDao dao;

    //CREATE
    public Book defineNewBook() throws NullTitleException, NullAuthorException,
            NullPublishedYearException, NullBookIdException {
        List<String> authorsList = new ArrayList<>();
        authorsList.add("Hall");
        authorsList.add("Smith");

        int id = dao.defineNewBook("Java Coding", authorsList, 1998);

        return this.getBookById(id);
    }

    //READ
    public List<Book> getAllBooks() {
        return dao.getAllBooks();
    }

    public Book getBookById(Integer id) throws NullBookIdException {
        return dao.getBookInfoById(id);
    }

    public List<Book> getBookByTitle(String title) throws NullTitleException {
        return dao.getBooksByTitle(title);
    }

    public List<Book> getBookByPublishedYear(Integer publishedYear) throws NullPublishedYearException {
        return dao.getBooksByPublishedYear(publishedYear);
    }

    //UPDATE
    public Book editBookTitle(Integer bookId, String title) throws NullBookIdException, NullTitleException {
        if(title == null)
            throw new NullTitleException("Tried to set book title to nothing.");

        Book toEdit = dao.getBookInfoById(bookId);//Get copy of book to edit
        toEdit.setTitle(title);//Edit the title
        dao.updateLibrary(toEdit);//Update the book in the library allBooks

        return getBookById(bookId);
    }

    public Book editBookAuthors(Integer bookId, List<String> author) throws NullBookIdException, NullAuthorException {
        if(author == null)
            throw new NullAuthorException("Tried to set authors list to nothing.");

        Book toEdit = dao.getBookInfoById(bookId);//Get copy of book to edit
        toEdit.setAuthors(author);//Edit the authors list
        dao.updateLibrary(toEdit);//Update the book in the library allBooks

        return getBookById(bookId);
    }

    public Book editBookPublishedYear(Integer bookId, Integer published) throws NullBookIdException, NullPublishedYearException {
        if(published == null)
            throw new NullPublishedYearException("Tried to set publish year to nothing.");

        Book toEdit = dao.getBookInfoById(bookId);//Get copy of book to edit
        toEdit.setPublishedYear(published);//Edit the year published
        dao.updateLibrary(toEdit);//Update the book in the library allBooks

        return getBookById(bookId);
    }

    //DELETE
    public void removeBook(Integer bookId) throws NullBookIdException {
        dao.removeBook(bookId);
    }

}
