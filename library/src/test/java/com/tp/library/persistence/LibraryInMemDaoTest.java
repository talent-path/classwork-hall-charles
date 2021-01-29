package com.tp.library.persistence;

import com.tp.library.exceptions.InvalidBookIdException;
import com.tp.library.exceptions.NullBookIdException;
import com.tp.library.models.Book;
import net.bytebuddy.matcher.FilterableList;
import org.junit.jupiter.api.BeforeEach;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;
import java.util.List;

@SpringBootTest
public class LibraryInMemDaoTest {

    @Autowired
    LibraryInMemDao toTest;

    @BeforeEach
    public void setUp() throws InvalidBookIdException, NullBookIdException {
        List<Book> allBooks = new ArrayList<>();

        for(Book toRemove : allBooks) {
            toTest.removeBook(toRemove.getBookId());
        }

        //TODO create book using defineBook method

    }

}
