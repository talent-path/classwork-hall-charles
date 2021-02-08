package com.tp.library.persistence;

import com.tp.library.exceptions.*;
import com.tp.library.models.Book;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class PostgresLibraryDao implements LibraryDao {

    @Autowired
    JdbcTemplate template;

    @Override
    public int defineNewBook(String title, List<String> authors, Integer published) throws NullTitleException, NullPublishedYearException, NullAuthorException, InvalidPublishedYearException {

        List<Integer> authorIdList = new ArrayList<>();

        for(String author : authors) {
            Integer authorId = addOrRetrieve(author);
            authorIdList.add(authorId);
        }

        return 0;
    }

    private Integer addOrRetrieve(String author) {

        Integer authorId = getAuthorId(author);

        if(authorId == null) {
           authorId = addAuthor(author);
        }

        return authorId;
    }

    private Integer getAuthorId(String author) {

        List<Integer> id = template.query("insert into \"Authors\" (\"authorName\")\n" +
                "values ('Edgar Allan Poe')\n" +
                "returning \""+author+"\";", new IdMapper());

        if(id.isEmpty())
            return null;

        return id.get(0);
    }

    @Override
    public List<Book> getAllBooks() {
        return null;
    }

    @Override
    public List<Book> getBooksByTitle(String title) throws NullTitleException {
        return null;
    }

    @Override
    public List<Book> getBooksByAuthor(String author) throws NullAuthorException {
        return null;
    }

    @Override
    public List<Book> getBooksByPublishedYear(Integer year) throws NullPublishedYearException, InvalidPublishedYearException {
        return null;
    }

    @Override
    public Book getBookInfoById(Integer bookId) throws NullBookIdException {
        return null;
    }

    @Override
    public void updateLibrary(Book book) throws NullBookException {

    }

    @Override
    public void removeBook(Integer bookId) throws NullBookIdException {

    }

    private int addAuthor(String author) {
        return template.query("insert into \"Authors\" (\"authorName\")\n" +
                "values ('"+author+"')\n" +
                "returning \"authorId\";", new IdMapper()).get(0);
    }

    private class IdMapper implements RowMapper<Integer> {
        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("authorId");
        }
    }

}
