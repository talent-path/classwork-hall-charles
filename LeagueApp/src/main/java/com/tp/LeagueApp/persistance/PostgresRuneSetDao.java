package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
public class PostgresRuneSetDao implements RuneSetDao {

    @Autowired
    JdbcTemplate template;

    @Override
    public List<RuneSet> getAllRuneSets() {
        List<RuneSet> allRuneSets = template.query("select * from \"RuneSets\"", new PostgresRuneSetDao.RuneSetMapper());

        return allRuneSets;
    }

    @Override
    public RuneSet getRuneSetByName(String runeSetName) {
        List<RuneSet> toReturn = template.query("select * from \"RuneSets\" where \"runeSetName\" = ?;", new PostgresRuneSetDao.RuneSetMapper(), runeSetName);

        return toReturn.get(0);
    }

    public class RuneSetMapper implements RowMapper<RuneSet> {

        @Override
        public RuneSet mapRow(ResultSet resultSet, int i) throws SQLException {
            RuneSet mappedRuneSet = new RuneSet();
            mappedRuneSet.setRuneSetId(resultSet.getInt("runeSetId"));
            mappedRuneSet.setRuneSetName(resultSet.getString("runeSetName"));
            mappedRuneSet.setChampionId(resultSet.getInt("championId"));

            return mappedRuneSet;
        }
    }

}
