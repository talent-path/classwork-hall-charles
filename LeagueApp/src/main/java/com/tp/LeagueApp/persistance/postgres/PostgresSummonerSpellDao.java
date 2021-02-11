package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.SummonerSpell;
import com.tp.LeagueApp.persistance.interfaces.SummonerSpellDao;
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
public class PostgresSummonerSpellDao implements SummonerSpellDao {
    @Autowired
    JdbcTemplate template;

    //READ
    @Override
    public List<SummonerSpell> getAllSummonerSpells() {
        List<SummonerSpell> allSummonerSpells = template.query("select * from \"SummonerSpells\"", new PostgresSummonerSpellDao.SummonerSpellMapper());

        return allSummonerSpells;
    }

    @Override
    public SummonerSpell getSummonerSpellByName(String summonerSpellName) throws NullNameException {

        if(summonerSpellName == null)
            throw new NullNameException("ERROR: Tried to get a summoner spell with a null name.");

        List<SummonerSpell> toReturn = template.query("select * from \"SummonerSpells\" where \"summSpellName\" = ?;", new PostgresSummonerSpellDao.SummonerSpellMapper(), summonerSpellName);

        return toReturn.get(0);
    }

    @Override
    public SummonerSpell getSummonerSpellById(Integer summonerSpellId) throws NullIdException {
        if(summonerSpellId == null)
            throw new NullIdException("ERROR: Tried to get a summoner spell with a null id.");

        List<SummonerSpell> toReturn = template.query("select * from \"SummonerSpells\" where \"summSpellId\" = ?;", new PostgresSummonerSpellDao.SummonerSpellMapper(), summonerSpellId);

        return toReturn.get(0);
    }

    public class SummonerSpellMapper implements RowMapper<SummonerSpell> {

        @Override
        public SummonerSpell mapRow(ResultSet resultSet, int i) throws SQLException {
            SummonerSpell mappedSummonerSpell = new SummonerSpell();
            mappedSummonerSpell.setSummonerSpellId(resultSet.getInt("summSpellId"));
            mappedSummonerSpell.setSummonerSpellName(resultSet.getString("summSpellName"));
            mappedSummonerSpell.setSummonerSpellDescription(resultSet.getString("summSpellDescription"));

            return mappedSummonerSpell;
        }
    }
}
