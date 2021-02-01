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

        //creates one book title TestOne, with author TestOne, pub year 1998
        toTest.defineNewBook( "TestOne", Arrays.asList("TestOne"), 1998);
    }

    //defineNewBook() test cases
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

    //getBooksByTitle() Test cases
    @Test
    public void getBooksByTitleGoldenPath() {
        try {
            List<Book> testList = toTest.getBooksByTitle("TestOne");

            assertEquals(1, testList.get(0).getBookId());
            assertEquals("TestOne", testList.get(0).getTitle());
            assertEquals(Arrays.asList("TestOne"), testList.get(0).getAuthors());
            assertEquals(1998, testList.get(0).getPublishedYear());

        } catch (NullTitleException e) {
            fail();
        }
    }

    @Test
    public void getBooksByTitleNullTitleTest() {
        try {
            List<Book> testList = toTest.getBooksByTitle(null);
            fail();
        } catch(NullTitleException e) {
            //Do nothing expected
        }
    }

    //getBooksByAuthor() Test cases
    @Test
    public void getBooksByAuthorGoldenPath() {
        try {
            List<Book> testList = toTest.getBooksByAuthor("TestOne");

            assertEquals(1, testList.get(0).getBookId());
            assertEquals("TestOne", testList.get(0).getTitle());
            assertEquals(Arrays.asList("TestOne"), testList.get(0).getAuthors());
            assertEquals(1998, testList.get(0).getPublishedYear());

        } catch (NullAuthorException e) {
            fail();
        }
    }

    @Test
    public void getBooksByAuthorNullAuthorTest() {
        try {
            List<Book> testList = toTest.getBooksByAuthor(null);
            fail();
        } catch(NullAuthorException e) {
            //Do nothing expected
        }
    }

    //getBooksByPublishedYear() Test cases
    @Test
    public void getBooksByPublishedYearGoldenPath() {
        try {
            List<Book> testList = toTest.getBooksByPublishedYear(1998);

            assertEquals(1, testList.get(0).getBookId());
            assertEquals("TestOne", testList.get(0).getTitle());
            assertEquals(Arrays.asList("TestOne"), testList.get(0).getAuthors());
            assertEquals(1998, testList.get(0).getPublishedYear());

        } catch (NullPublishedYearException | InvalidPublishedYearException e) {
            fail();
        }
    }

    @Test
    public void getBooksByPublishedYearNullYearTest() {
        try {
            List<Book> testList = toTest.getBooksByPublishedYear(null);
            fail();
        } catch(NullPublishedYearException e) {
            //Do nothing expected
        } catch (InvalidPublishedYearException e) {
            fail();
        }
    }

    @Test
    public void getBooksByPublishedYearInvalidYearTest() {
        try {
            List<Book> testList = toTest.getBooksByPublishedYear(100);
            fail();
        } catch(NullPublishedYearException e) {
            fail();
        } catch (InvalidPublishedYearException e) {
            //Do nothing expected
        }
    }

    //getBookInfoById() test cases
    @Test
    public void getBooksByIdGoldenPath() {
        try {
            Book book = toTest.getBookInfoById(1);

            assertEquals(1, book.getBookId());
            assertEquals("TestOne", book.getTitle());
            assertEquals(Arrays.asList("TestOne"), book.getAuthors());
            assertEquals(1998, book.getPublishedYear());

        } catch (NullBookIdException e) {
            fail();
        }
    }

    @Test
    public void getBooksByIdNullIdTest() {
        try {
            Book book = toTest.getBookInfoById(null);
            fail();
        } catch(NullBookIdException e) {
            //Do nothing expected
        }
    }

}
