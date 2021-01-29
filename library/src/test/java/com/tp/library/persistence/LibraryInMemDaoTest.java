package com.tp.library.persistence;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import static org.junit.jupiter.api.Assertions.*;

import java.util.Arrays;
import java.util.List;

@SpringBootTest
public class LibraryInMemDaoTest {

    @Autowired
    LibraryInMemDao toTest;

    @BeforeEach
    public void setup() throws NullAuthorException, InvalidPublishedYearException,
            NullTitleException, NullPublishedYearException, NullBookIdException {
        List<Book> allGames = toTest.getAllBooks();

        for( Book toRemove : allGames ){
            toTest.removeBook( toRemove.getBookId() );
        }

        //creates one game with "zebra" and id = 1
        toTest.defineNewBook( "TestOne", Arrays.asList("TestOne"), 1998);
    }

    @Test
    public void defineNewBookGoldenPath() {
        try {
            String testTitle = "TestTwo";
            List<String> testAuthors = Arrays.asList("TestTwo");
            Integer testPublished = 1998;

            int id = toTest.defineNewBook(testTitle, testAuthors, testPublished);

            assertEquals(2, id);

            Book testBook = toTest.getBookInfoById(id);

            assertEquals("TestTwo", testBook.getTitle());
            assertEquals(Arrays.asList("TestTwo"), testBook.getAuthors());
            assertEquals(1998, testBook.getPublishedYear());

        } catch (NullTitleException | NullBookIdException | NullAuthorException |
                NullPublishedYearException | InvalidPublishedYearException e) {
            fail();
        }
    }

    @Test
    public void defineNewBookNullTitleTest() {
        try {
            String testTitle = null;
            List<String> testAuthors = Arrays.asList("TestThree");
            Integer testPublished = 1998;

            int id = toTest.defineNewBook(testTitle, testAuthors, testPublished);
            fail();
        }catch (InvalidPublishedYearException | NullAuthorException | NullPublishedYearException e) {
            fail();
        } catch (NullTitleException e) {
            //Do nothing expected
        }
    }

    @Test
    public void defineNewBookNullAuthorsTest() {
        try {
            String testTitle = "TestFour";
            List<String> testAuthors = null;
            Integer testPublished = 1998;

            int id = toTest.defineNewBook(testTitle, testAuthors, testPublished);
            fail();
        }catch (InvalidPublishedYearException | NullTitleException | NullPublishedYearException e) {
            fail();
        } catch (NullAuthorException e) {
            //Do nothing expected
        }
    }

    @Test
    public void defineNewBookNullPublishedYearTest() {
        try {
            String testTitle = "TestFive";
            List<String> testAuthors = Arrays.asList("TestFive");
            Integer testPublished = null;

            int id = toTest.defineNewBook(testTitle, testAuthors, testPublished);
            fail();
        }catch (InvalidPublishedYearException | NullTitleException | NullAuthorException e) {
            fail();
        } catch (NullPublishedYearException e) {
            //Do nothing expected
        }
    }

    @Test
    public void defineNewBookInvalidPublishedYearTest() {
        try {
            String testTitle = "TestFive";
            List<String> testAuthors = Arrays.asList("TestFive");
            Integer testPublished = 0;

            int id = toTest.defineNewBook(testTitle, testAuthors, testPublished);
            fail();
        }catch (NullPublishedYearException | NullTitleException | NullAuthorException e) {
            fail();
        } catch (InvalidPublishedYearException e) {
            //Do nothing expected
        }
    }

    @Test
    public void getBooksByTitleGoldenPath() {
        try {
            List<Book> testList = toTest.getBooksByTitle("Test");
            //TODO finish implementing
        } catch (NullTitleException e) {
            fail();
        }
    }

}
