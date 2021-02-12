package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.*;
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

    //CREATE
    @Override
    public SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) throws NullSetException, EmptySummonerSpellListException, InvalidSummonerSpellException {

        if(toAdd == null)
            throw new NullSetException("ERROR: Tried to create a null summoner spell set.");
        if(toAdd.getSummonerSpellIdList().size() == 0)
            throw new EmptySummonerSpellListException("ERROR: Empty item list.");

        //Add validate items
        if(!validateSummonerSpellList(toAdd.getSummonerSpellIdList()))
            throw new InvalidSummonerSpellException("Summoner spell in list is not valid.");

        Integer summSpellSetId = template.queryForObject("insert into \"SummonerSpellSets\" (\"summSpellSetName\", \"championId\") values (?, ?) RETURNING \"summSpellSetId\";",
                new PostgresSummonerSpellSetDao.SummonerSpellSetIdMapper(),
                toAdd.getSummonerSpellSetName(),
                toAdd.getChampionId()
        );

        //Add insert into bridge
        for(Integer summSpellIdToAdd : toAdd.getSummonerSpellIdList()) {
            template.update("insert into \"SummonerSpellSetSummonerSpells\" (\"summSpellSetId\", \"summSpellId\") values ('"+summSpellSetId+"', '"+summSpellIdToAdd+"')");
        }

        toAdd.setSummonerSpellSetId(summSpellSetId);

        return toAdd;
    }

    private boolean validateSummonerSpellList(List<Integer> toCheck) {
        boolean equal = true;

        Integer queryCount = 0;

        for(Integer toValidate : toCheck) {
            queryCount += template.queryForObject("select COUNT(*) from \"SummonerSpells\" where \"summSpellId\" in (?)", new SummonerSpellSetCountMapper(), toValidate);
        }

        Integer toCheckCount = toCheck.size();

        if(!queryCount.equals(toCheckCount))
            equal = false;

        return equal;
    }

    //READ
    @Override
    public List<SummonerSpellSet> getAllSummonerSpellSets() {
        List<SummonerSpellSet> allSummonerSpellSets = template.query("select * from \"SummonerSpellSets\"", new PostgresSummonerSpellSetDao.SummonerSpellSetMapper());

        return allSummonerSpellSets;
    }

    @Override
    public SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName) throws NullNameException {

        if(summonerSpellSetName == null)
            throw new NullNameException("ERROR: Tried to get a summoner spell set with a null name.");

        List<SummonerSpellSet> toReturn = template.query("select * from \"SummonerSpellSets\" where \"summSpellSetName\" = ?;", new PostgresSummonerSpellSetDao.SummonerSpellSetMapper(), summonerSpellSetName);

        return toReturn.get(0);
    }

    @Override
    public SummonerSpellSet getSummonerSpellSetById(Integer summonerSpellSetId) throws NullIdException, InvalidSetException {

        if(summonerSpellSetId == null)
            throw new NullIdException("ERROR: Tried to get a summoner spell set with a null name.");
        if(!validateId(summonerSpellSetId))
            throw new InvalidSetException("ERROR: Tried to get a summoner spell set that doesn't exist.");

        List<SummonerSpellSet> toReturn = template.query("select * from \"SummonerSpellSets\" where \"summSpellSetId\" = ?;", new PostgresSummonerSpellSetDao.SummonerSpellSetMapper(), summonerSpellSetId);

        return toReturn.get(0);
    }

    //UPDATE
    @Override
    public void updateSummonerSpellSet(SummonerSpellSet toUpdate) throws NullSetException, NullIdException, InvalidSetException {

        if(toUpdate == null)
            throw new NullSetException("ERROR: Tried to update summoner spell set with a null summoner spell set.");
        if(toUpdate.getSummonerSpellSetId() == null)
            throw new NullIdException("ERROR: Tried to update a summoner spell set with a null id.");
        if(!validateId(toUpdate.getSummonerSpellSetId()))
            throw new InvalidSetException("ERROR: Tried to delete a set that doesn't exist.");

        template.update("update \"SummonerSpellSets\" set \"summSpellSetName\" = ?, \"championId\" = ? where \"summSpellSetId\" = ?",
                toUpdate.getSummonerSpellSetName(), toUpdate.getChampionId(), toUpdate.getSummonerSpellSetId());

    }

    //DELETE
    @Override
    public void deleteSummonerSpellSet(String toDelete) throws NullNameException {

        if(toDelete == null)
            throw new NullNameException("ERROR: Tried to delete a summoner spell set with a null name.");

        template.update("delete from \"SummonerSpellSets\" where \"summSpellSetName\" = ?;", toDelete);
    }

    @Override
    public void deleteSummonerSpellSetById(Integer toDeleteId) throws NullIdException, InvalidSetException {

        if(toDeleteId == null)
            throw new NullIdException("ERROR: Tried to delete a summoner spell set with a null id.");
        if(!validateId(toDeleteId))
            throw new InvalidSetException("ERROR: Tried to delete a set that doesn't exist.");

        template.update("delete from \"SummonerSpellSetSummonerSpells\" where \"summSpellSetId\" = ?;", toDeleteId);
        template.update("delete from \"SummonerSpellSets\" where \"summSpellSetId\" = ?;", toDeleteId);
    }

    private boolean validateId(Integer toValidate) {

        boolean exists = true;

        Integer returnCount = template.queryForObject("select COUNT(*) from \"SummonerSpells\" where \"summSpellId\" in (?)", new SummonerSpellSetCountMapper(), toValidate);

        Integer zero = 0;

        if(returnCount.equals(zero))
            exists = false;

        return exists;
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

    private class SummonerSpellSetIdMapper implements RowMapper<Integer> {
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("summSpellSetId");
        }
    }

    private class SummonerSpellSetCountMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("count");
        }
    }
}
