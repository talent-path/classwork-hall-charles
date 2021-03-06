package com.tp.library.controllers;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;
import com.tp.library.services.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.swing.*;
import java.util.ArrayList;
import java.util.List;

@RestController
public class LibraryController {

    @Autowired
    LibraryService service;

    //CREATE
    @PostMapping("/new")//Generates the default book
    public ResponseEntity defineNewBook() throws NullBookIdException, NullTitleException,
            NullAuthorException, NullPublishedYearException, InvalidPublishedYearException {
        Book toReturn = null;
        try {
            toReturn = service.defineNewBook();
        }
        catch(NullBookIdException | NullTitleException | NullAuthorException | NullPublishedYearException
                | InvalidPublishedYearException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }
        return ResponseEntity.ok(toReturn);
    }

    @PostMapping("/new/user")//User defined books using request body
    public ResponseEntity defineNewUserBook(@RequestBody NewBookRequest request) throws NullBookIdException, NullTitleException,
            NullAuthorException, NullPublishedYearException, InvalidPublishedYearException {

        Book toReturn = null;
        try {
            toReturn = service.defineNewUserBook(request.getTitle(), request.getAuthors(), request.getPublishedYear());
        }
        catch (NullBookIdException | NullTitleException | NullAuthorException |
                NullPublishedYearException | InvalidPublishedYearException | EmptyTitleException |
                EmptyAuthorListException | EmptyAuthorException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //READ
    @GetMapping("/library")
    public ResponseEntity getAllBooks() {
        List<Book> toReturn = service.getAllBooks();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/library/bookId/{bookId}")//Get book by id
    public ResponseEntity getBookById(@PathVariable Integer bookId) throws NullBookIdException {
        Book toReturn = null;
        try {
            toReturn = service.getBookById(bookId);
        }
        catch(NullBookIdException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/library/title/{title}")//Get book by title
    public ResponseEntity getBooksByTitle(@PathVariable String title) throws NullTitleException, EmptyTitleException {
        List<Book> toReturn = new ArrayList<>();
        try {
            toReturn = service.getBooksByTitle(title);
        }
        catch(NullTitleException | EmptyTitleException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/library/published/{publishedYear}")//Get book by published year
    public ResponseEntity getBooksByPublishedYear(@PathVariable Integer publishedYear) throws NullPublishedYearException,
            InvalidPublishedYearException {
        List<Book> toReturn = new ArrayList<>();
        try {
            toReturn = service.getBooksByPublishedYear(publishedYear);
        }
        catch(NullPublishedYearException | InvalidPublishedYearException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/library/author/{author}")//Get book by author
    public ResponseEntity getBooksByAuthor(@PathVariable String author) throws NullAuthorException,
            EmptyAuthorException {
        List<Book> toReturn = new ArrayList<>();
        try {
            toReturn = service.getBooksByAuthor(author);
        }
        catch(NullAuthorException | EmptyAuthorException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //UPDATE
    @PutMapping("/edit/title")
    public ResponseEntity editTitle(@RequestBody UpdateTitleRequest request) throws NullBookIdException, NullTitleException, NullBookException {
        Book toReturn = null;
        try {
            toReturn = service.editBookTitle(request.getBookId(), request.getNewTitle());
        }
        catch(NullBookIdException | NullTitleException | NullBookException | EmptyTitleException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PutMapping("/edit/author")
    public ResponseEntity editAuthor(@RequestBody UpdateAuthorRequest request) throws NullBookIdException, NullAuthorException, NullBookException {
        Book toReturn = null;
        try {
            toReturn = service.editBookAuthors(request.getBookId(), request.getNewAuthors());
        }
        catch(NullBookIdException | NullAuthorException | NullBookException | EmptyAuthorException | EmptyAuthorListException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PutMapping("/edit/published")
    public ResponseEntity editPublished(@RequestBody UpdatePublishRequest request) throws NullBookIdException, NullPublishedYearException,
            InvalidPublishedYearException, NullBookException {
        Book toReturn = null;
        try {
            toReturn = service.editBookPublishedYear(request.getBookId(), request.getNewPublishedYear());
        }
        catch(NullBookIdException | NullPublishedYearException | InvalidPublishedYearException | NullBookException e) {
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
