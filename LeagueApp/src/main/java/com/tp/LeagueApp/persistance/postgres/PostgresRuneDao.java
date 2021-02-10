package com.tp.LeagueApp.persistance.postgres;

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

    @Override
    public List<Rune> getAllRunes() {
        List<Rune> allRunes = template.query("select * from \"Runes\"", new PostgresRuneDao.RuneMapper());

        return allRunes;
    }

    @Override
    public Rune getRuneByName(String runeName) {
        List<Rune> toReturn = template.query("select * from \"Runes\" where \"runeName\" = ?;", new PostgresRuneDao.RuneMapper(), runeName);

        return toReturn.get(0);
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
}
