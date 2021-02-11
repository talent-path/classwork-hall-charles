package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.persistance.interfaces.RuneSetDao;
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
public class PostgresRuneSetDao implements RuneSetDao {

    @Autowired
    JdbcTemplate template;

    //CREATE
    @Override
    public RuneSet createNewRuneSet(RuneSet toAdd) throws NullSetException {

        if(toAdd == null)
            throw new NullSetException("ERROR: Tried to create a null rune set.");

        Integer runeSetId = template.queryForObject("insert into \"RuneSets\" (\"runeSetName\", \"championId\") values (?, ?) RETURNING \"runeSetId\";",
                new PostgresRuneSetDao.RuneSetIdMapper(),
                toAdd.getRuneSetName(),
                toAdd.getChampionId()
        );

        toAdd.setRuneSetId(runeSetId);

        return toAdd;
    }

    //READ
    @Override
    public List<RuneSet> getAllRuneSets() {
        List<RuneSet> allRuneSets = template.query("select * from \"RuneSets\"", new PostgresRuneSetDao.RuneSetMapper());

        return allRuneSets;
    }

    @Override
    public RuneSet getRuneSetByName(String runeSetName) throws NullNameException {

        if(runeSetName == null)
            throw new NullNameException("ERROR: Tried to get a rune set with a null name.");

        List<RuneSet> toReturn = template.query("select * from \"RuneSets\" where \"runeSetName\" = ?;", new PostgresRuneSetDao.RuneSetMapper(), runeSetName);

        return toReturn.get(0);
    }

    @Override
    public RuneSet getRuneSetById(Integer runeSetId) throws NullIdException {

        if(runeSetId == null)
            throw new NullIdException("ERROR: Tried to get a rune set with a null id.");

        List<RuneSet> toReturn = template.query("select * from \"RuneSets\" where \"runeSetId\" = ?;", new PostgresRuneSetDao.RuneSetMapper(), runeSetId);

        return toReturn.get(0);
    }

    //UPDATE
    @Override
    public void updateRuneSet(RuneSet toUpdate) throws NullSetException, NullIdException {

        if(toUpdate == null)
            throw new NullSetException("ERROR: Tried to update rune set with a null rune set.");
        if(toUpdate.getRuneSetId() == null)
            throw new NullIdException("ERROR: Tried to update a rune set with a null id.");

        template.update("update \"RuneSets\" set \"runeSetName\" = ?, \"championId\" = ? where \"runeSetId\" = ?",
                toUpdate.getRuneSetName(), toUpdate.getChampionId(), toUpdate.getRuneSetId());

    }

    //DELETE
    @Override
    public void deleteRuneSet(String toDelete) throws NullNameException {

        if(toDelete == null)
            throw new NullNameException("ERROR: Tried to delete a rune set with a null name.");

        template.update("delete from \"RuneSets\" where \"runeSetName\" = ?;", toDelete);
    }

    @Override
    public void deleteRuneSetById(Integer toDeleteId) throws NullIdException {

        if(toDeleteId == null)
            throw new NullIdException("ERROR: Tried to delete a rune set with a null id.");

        template.update("delete from \"RuneSets\" where \"runeSetId\" = ?;", toDeleteId);
    }

    private class RuneSetMapper implements RowMapper<RuneSet> {

        @Override
        public RuneSet mapRow(ResultSet resultSet, int i) throws SQLException {
            RuneSet mappedRuneSet = new RuneSet();
            mappedRuneSet.setRuneSetId(resultSet.getInt("runeSetId"));
            mappedRuneSet.setRuneSetName(resultSet.getString("runeSetName"));
            mappedRuneSet.setChampionId(resultSet.getInt("championId"));

            return mappedRuneSet;
        }
    }

    private class RuneSetIdMapper implements RowMapper<Integer>{
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("runeSetId");
        }
    }

}
