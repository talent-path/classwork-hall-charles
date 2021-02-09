package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.models.Champion;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Component;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

@Component
public class PostgresChampionDao implements ChampionDao {

    @Autowired
    JdbcTemplate template;

    @Override
    public List<Champion> getAllChampions() {
        List<Champion> allChampions = template.query("select * from \"Champions\"", new ChampionMapper());

        return allChampions;
    }

    @Override
    public Champion getChampionByName(String championName) {
        List<Champion> toReturn = template.query("select * from \"Champions\" where \"championName\" = ?;", new ChampionMapper(), championName);

        return toReturn.get(0);
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
}
