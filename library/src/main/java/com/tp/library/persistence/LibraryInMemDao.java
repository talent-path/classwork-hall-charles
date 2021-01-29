package com.tp.library.persistence;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class LibraryInMemDao implements LibraryDao{

    private List<Book> allBooks = new ArrayList<>();

    //Constructor for testing purposes
    public LibraryInMemDao() {
        Book firstBook = new Book(1, "Java Coding", Arrays.asList("Hall", "Smith"), 1998);
        allBooks.add(firstBook);
    }

    //CREATE
    @Override
    public int defineNewBook(String title, List<String> authors, Integer published)
            throws InvalidTitleException, InvalidAuthorException,InvalidPublishedYearException, NullTitleException,
            NullAuthorException, NullPublishedYearException {
        if(title == null)//Check exceptions
            throw new NullTitleException("Tried to define new book without a title.");
        if(authors == null)
            throw new NullAuthorException("Tried to define a new book without an author/authors.");
        if(published == null)
            throw new NullPublishedYearException("Tried to define a new book without a published year.");

        //Make new id
        int id = 0;
        //Iterate to highest id
        for(Book toCheck : allBooks) {
            if(toCheck.getBookId() > id)
                id = toCheck.getBookId();
        }
        //Make new id one higher
        id++;

        //Create new book object with new info and add to all books
        Book toAdd = new Book(id, title, authors, published);
        allBooks.add(toAdd);
        return id;
    }

    //READ
    @Override
    public List<Book> getAllBooks() {
        List<Book> copyList = new ArrayList<>();
        for( Book toCopy : allBooks ){
            copyList.add( new Book(toCopy) );
        }
        return copyList;
    }

    @Override
    public List<Book> getBooksByTitle(String title) throws InvalidTitleException, NullTitleException{

        if(title == null)
            throw new NullTitleException("Book title is null.");

        List<Book> toReturn = new ArrayList<>();

        return null;
    }

    @Override
    public List<Book> getBooksByAuthor(List<String> author) throws InvalidAuthorException, NullAuthorException {
        return null;
    }

    @Override
    public List<Book> getBooksByPublishedYear(Integer year) throws InvalidPublishedYearException, NullPublishedYearException{
        return null;
    }

    @Override
    public Book getBookInfoById(Integer bookId) throws InvalidBookIdException, NullBookIdException {
        return null;
    }

    //UPDATE
    @Override
    public void updateBook(Integer bookId) throws InvalidBookIdException, NullBookIdException{

    }

    //DELETE
    @Override
    public void removeBook(Integer bookId) throws InvalidBookIdException, NullBookIdException{

    }
}
