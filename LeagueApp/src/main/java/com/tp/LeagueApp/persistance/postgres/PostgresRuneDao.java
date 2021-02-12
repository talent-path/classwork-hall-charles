package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.InvalidSetException;
import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Rune;
import com.tp.LeagueApp.persistance.interfaces.RuneDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
@Profile({"production","daoTesting"})
public class PostgresRuneDao implements RuneDao {

    @Autowired
    JdbcTemplate template;

    //READ
    @Override
    public List<Rune> getAllRunes() {
        List<Rune> allRunes = template.query("select * from \"Runes\"", new PostgresRuneDao.RuneMapper());

        return allRunes;
    }

    @Override
    public Rune getRuneByName(String runeName) throws NullNameException {

        if(runeName == null)
            throw new NullNameException("ERROR: Tried to get a rune with a null name.");

        List<Rune> toReturn = template.query("select * from \"Runes\" where \"runeName\" = ?;", new PostgresRuneDao.RuneMapper(), runeName);

        return toReturn.get(0);
    }

    @Override
    public Rune getRuneById(Integer runeId) throws NullIdException, InvalidSetException {
        if(runeId == null)
            throw new NullIdException("ERROR: Tried to get a rune with a null id.");
        if(!validateId(runeId))
            throw new InvalidSetException("ERROR: Tried to get a rune that doesn't exist.");

        List<Rune> toReturn = template.query("select * from \"Runes\" where \"runeId\" = ?;", new PostgresRuneDao.RuneMapper(), runeId);

        return toReturn.get(0);
    }

    private boolean validateId(Integer toValidate) {

        boolean exists = true;

        Integer returnCount = template.queryForObject("select COUNT(*) from \"Runes\" where \"runeId\" in (?)", new RuneCountMapper(), toValidate);

        Integer zero = 0;

        if(returnCount.equals(zero))
            exists = false;

        return exists;
    }

    public class RuneMapper implements RowMapper<Rune> {

        @Override
        public Rune mapRow(ResultSet resultSet, int i) throws SQLException {
            Rune mappedRune = new Rune();
            mappedRune.setRuneId(resultSet.getInt("runeId"));
            mappedRune.setRuneName(resultSet.getString("runeName"));
            mappedRune.setRuneDescription(resultSet.getString("runeDescription"));

            return mappedRune;
        }
    }

    private class RuneCountMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("count");
        }
    }
}
