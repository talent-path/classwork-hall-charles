package com.tp.library.persistence;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;
import org.springframework.stereotype.Component;

import java.util.*;

@Component
public class LibraryInMemDao implements LibraryDao{

    private List<Book> allBooks = new ArrayList<>();

    //CREATE
    @Override
    public int defineNewBook(String title, List<String> authors, Integer published)
            throws NullTitleException,
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
    public List<Book> getBooksByTitle(String title) throws NullTitleException{
        //Check for null title
        if(title == null)
            throw new NullTitleException("Book title is null.");

        List<Book> toReturn = new ArrayList<>();//Create list of books
        //Iterate through all books
        for(Book toCheck : allBooks) {
            if(toCheck.getTitle().equals(title)) {//If the book has the title
                toReturn.add(toCheck);//Add to list
            }
        }

        return toReturn;
    }

    @Override
    public List<Book> getBooksByAuthor(String author) throws NullAuthorException {
        if(author == null)
            throw new NullAuthorException("Authors list is null");

        List<Book> toReturn = new ArrayList<>();//Create list of books

        //Iterate through all books
        for(Book toCheck : allBooks) {
            if(toCheck.getAuthors().contains(author)) {//If the books contain at least one of the authors
                toReturn.add(toCheck);
            }
        }

        return toReturn;
    }

    @Override
    public List<Book> getBooksByPublishedYear(Integer year) throws NullPublishedYearException {
        if(year == null)
            throw new NullPublishedYearException("Published year is null.");

        List<Book> toReturn = new ArrayList<>();//Create list of books
        //Iterate through all books
        for(Book toCheck : allBooks) {
            if(toCheck.getPublishedYear().equals(year)) {//If the book has published year
                toReturn.add(toCheck);//Add to list
            }
        }

        return toReturn;
    }

    @Override
    public Book getBookInfoById(Integer bookId) throws NullBookIdException {
        if(bookId == null)
            throw new NullBookIdException("Tried to get information from book with no id.");

        Book toReturn = null;
        //Check all books for matching id
        for(Book toCheck : allBooks) {
            if(toCheck.getBookId().equals(bookId)) {
                toReturn = new Book(toCheck);//Use copy constructor
                break;
            }
        }
        return toReturn;
    }

    //UPDATE
    @Override
    public void updateLibrary(Book book) {
        //Search through all books
        for(int i = 0; i < allBooks.size(); i++) {
            if(allBooks.get(i).getBookId().equals(book.getBookId())) {//Find matching book
                allBooks.set(i, new Book(book));//Update book in all games
            }
        }
    }

    //DELETE
    @Override
    public void removeBook(Integer bookId) throws NullBookIdException {
        if(bookId == null)
            throw new NullBookIdException("Book Id is null.");

        int removeIndex = -1;

        for(int i = 0; i < allBooks.size(); i++) {//Iterate through all books
            if(allBooks.get(i).getBookId().equals(bookId)) {//Find matching book id
                removeIndex = i;//Grab the index of the book we want to remove
                break;
            }
        }

        if(removeIndex != -1) {
            allBooks.remove(removeIndex);
        }
        else {
            throw new NullBookIdException("Could not find game with ID " + bookId + " in library.");
        }
    }
}
