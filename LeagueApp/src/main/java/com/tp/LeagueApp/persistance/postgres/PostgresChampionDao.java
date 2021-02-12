package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.InvalidSetException;
import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.persistance.interfaces.ChampionDao;
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
public class PostgresChampionDao implements ChampionDao {

    @Autowired
    JdbcTemplate template;

    //READ
    @Override
    public List<Champion> getAllChampions() {
        List<Champion> allChampions = template.query("select * from \"Champions\"", new ChampionMapper());

        return allChampions;
    }

    @Override
    public Champion getChampionByName(String championName) throws NullNameException {

        if(championName == null)
            throw new NullNameException("ERROR: Tried to get champion with null name.");

        List<Champion> toReturn = template.query("select * from \"Champions\" where \"championName\" = ?;", new ChampionMapper(), championName);

        return toReturn.get(0);
    }

    @Override
    public Champion getChampionById(Integer championId) throws NullIdException, InvalidSetException {
        if(championId == null)
            throw new NullIdException("ERROR: Tried to get champion with null id.");
        if(!validateId(championId))
            throw new InvalidSetException("ERROR: Tried to get a champion that doesn't exist.");

        List<Champion> toReturn = template.query("select * from \"Champions\" where \"championId\" = ?;", new ChampionMapper(), championId);

        return toReturn.get(0);
    }

    private boolean validateId(Integer toValidate) {

        boolean exists = true;

        Integer returnCount = template.queryForObject("select COUNT(*) from \"Champions\" where \"championId\" in (?)", new ChampionCountMapper(), toValidate);

        Integer zero = 0;

        if(returnCount.equals(zero))
            exists = false;

        return exists;
    }

    class ChampionMapper implements RowMapper<Champion> {

        @Override
        public Champion mapRow(ResultSet resultSet, int i) throws SQLException {
            Champion mappedChampion = new Champion();
            mappedChampion.setChampionId(resultSet.getInt("championId"));
            mappedChampion.setChampionName(resultSet.getString("championName"));
            mappedChampion.setChampionDescription(resultSet.getString("championDescription"));
            mappedChampion.setWinRate(resultSet.getBigDecimal("winRate"));
            mappedChampion.setPickRate(resultSet.getBigDecimal("pickRate"));
            mappedChampion.setBanRate(resultSet.getBigDecimal("banRate"));
            mappedChampion.setAvgKDA(resultSet.getBigDecimal("avgKDA"));

            return mappedChampion;
        }
    }

    private class ChampionCountMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("count");
        }
    }
}
