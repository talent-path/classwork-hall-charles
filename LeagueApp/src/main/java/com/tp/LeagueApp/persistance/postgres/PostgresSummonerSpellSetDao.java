package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.models.SummonerSpellSet;
import com.tp.LeagueApp.persistance.interfaces.SummonerSpellSetDao;
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
public class PostgresSummonerSpellSetDao implements SummonerSpellSetDao {
    @Autowired
    JdbcTemplate template;

    @Override
    public List<SummonerSpellSet> getAllSummonerSpellSets() {
        List<SummonerSpellSet> allSummonerSpellSets = template.query("select * from \"SummonerSpellSets\"", new PostgresSummonerSpellSetDao.SummonerSpellSetMapper());

        return allSummonerSpellSets;
    }

    @Override
    public SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName) {
        List<SummonerSpellSet> toReturn = template.query("select * from \"SummonerSpellSets\" where \"summSpellSetName\" = ?;", new PostgresSummonerSpellSetDao.SummonerSpellSetMapper(), summonerSpellSetName);

        return toReturn.get(0);
    }

    @Override
    public SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) {
        Integer summSpellSetId = template.queryForObject("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (?, ?) RETURNING \"summSpellSetId\";",
                new PostgresSummonerSpellSetDao.SummonerSpellSetIdMapper(),
                toAdd.getSummonerSpellSetName(),
                toAdd.getChampionId()
        );

        toAdd.setSummonerSpellSetId(summSpellSetId);

        return toAdd;
    }

    public class SummonerSpellSetMapper implements RowMapper<SummonerSpellSet> {

        @Override
        public SummonerSpellSet mapRow(ResultSet resultSet, int i) throws SQLException {
            SummonerSpellSet mappedSummonerSpellSet = new SummonerSpellSet();
            mappedSummonerSpellSet.setSummonerSpellSetId(resultSet.getInt("summSpellSetId"));
            mappedSummonerSpellSet.setSummonerSpellSetName(resultSet.getString("summSpellSetName"));
            mappedSummonerSpellSet.setChampionId(resultSet.getInt("championId"));

            return mappedSummonerSpellSet;
        }
    }

    private class SummonerSpellSetIdMapper implements RowMapper<Integer>{
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("summSpellSetId");
        }
    }
}
