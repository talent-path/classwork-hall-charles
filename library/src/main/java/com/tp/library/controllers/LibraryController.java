package com.tp.library.controllers;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;
import com.tp.library.services.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class LibraryController {

    @Autowired
    LibraryService service;

    //CREATE
    @PostMapping("/new")//Generates the default book
    public Book defineNewBook() throws NullBookIdException, NullTitleException,
            NullAuthorException, NullPublishedYearException, InvalidPublishedYearException {
        Book book = service.defineNewBook();
        return book;
    }

    @PostMapping("/new/user")//User defined books using request body
    public ResponseEntity defineNewUserBook(@RequestBody NewBookRequest request) throws NullBookIdException, NullTitleException,
            NullAuthorException, NullPublishedYearException, InvalidPublishedYearException {

        Book toReturn = null;
        try {
            toReturn = service.defineNewUserBook(request.getTitle(), request.getAuthors(), request.getPublishedYear());
        }
        catch (NullBookIdException | NullTitleException | NullAuthorException
                | NullPublishedYearException | InvalidPublishedYearException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //READ
    @GetMapping("/library")
    public List<Book> getAllBooks() {
        return service.getAllBooks();
    }

    @GetMapping("/library/bookId/{bookId}")//Get book by id
    public Book getBookById(@PathVariable Integer bookId) throws NullBookIdException {
        return service.getBookById(bookId);
    }

    @GetMapping("/library/title/{title}")//Get book by title
    public List<Book> getBookByTitle(@PathVariable String title) throws NullTitleException {
        return service.getBookByTitle(title);
    }

    @GetMapping("/library/published/{publishedYear}")//Get book by published year
    public List<Book> getBookByPublishedYear(@PathVariable Integer publishedYear) throws NullPublishedYearException, InvalidPublishedYearException {
        return service.getBookByPublishedYear(publishedYear);
    }

    @GetMapping("/library/author/{author}")//Get book by author
    public List<Book> getBookByAuthor(@PathVariable String author) throws NullAuthorException {
        return service.getBookByAuthor(author);
    }

    //UPDATE
    @PutMapping("/edit/title")
    public ResponseEntity editTitle(@RequestBody UpdateTitleRequest request) throws NullBookIdException, NullTitleException {
        Book toReturn = null;
        try {
            toReturn = service.editBookTitle(request.getBookId(), request.getNewTitle());
        }
        catch(NullBookIdException | NullTitleException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PutMapping("/edit/author")
    public ResponseEntity editAuthor(@RequestBody UpdateAuthorRequest request) throws NullBookIdException, NullAuthorException {
        Book toReturn = null;
        try {
            toReturn = service.editBookAuthors(request.getBookId(), request.getNewAuthors());
        }
        catch(NullBookIdException | NullAuthorException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PutMapping("/edit/published")
    public ResponseEntity editPublished(@RequestBody UpdatePublishRequest request) throws NullBookIdException, NullPublishedYearException,
            InvalidPublishedYearException {
        Book toReturn = null;
        try {
            toReturn = service.editBookPublishedYear(request.getBookId(), request.getNewPublishedYear());
        }
        catch(NullBookIdException | NullPublishedYearException | InvalidPublishedYearException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //DELETE
    @DeleteMapping("/remove/{bookId}")
    public String removeBook(@PathVariable Integer bookId) throws NullBookIdException {
        try {
            service.removeBook(bookId);
            return "Book " + bookId + "successfully deleted.";
        }
        catch(NullBookIdException e) {
            return e.getMessage();
        }
    }
}