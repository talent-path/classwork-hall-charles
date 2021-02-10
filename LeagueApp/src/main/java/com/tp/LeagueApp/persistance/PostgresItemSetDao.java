package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.models.ItemSet;
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
public class PostgresItemSetDao implements ItemSetDao {
    @Autowired
    JdbcTemplate template;

    @Override
    public List<ItemSet> getAllItemSets() {
        List<ItemSet> allItemSets = template.query("select * from \"ItemSets\"", new PostgresItemSetDao.ItemSetMapper());

        return allItemSets;
    }

    @Override
    public ItemSet getItemSetByName(String itemSetName) {
        List<ItemSet> toReturn = template.query("select * from \"ItemSets\" where \"itemSetName\" = ?;", new PostgresItemSetDao.ItemSetMapper(), itemSetName);

        return toReturn.get(0);
    }

    @Override
    public ItemSet createNewItemSet(ItemSet toAdd) {
        Integer itemSetId = template.queryForObject("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (?, ?);",
                new ItemSetIdMapper(),
                toAdd.getItemSetName(),
                toAdd.getChampionId()
        );

        toAdd.setItemSetId(itemSetId);

        return toAdd;
    }

    private class ItemSetMapper implements RowMapper<ItemSet> {

        @Override
        public ItemSet mapRow(ResultSet resultSet, int i) throws SQLException {
            ItemSet mappedItemSet = new ItemSet();
            mappedItemSet.setItemSetId(resultSet.getInt("itemSetId"));
            mappedItemSet.setItemSetName(resultSet.getString("itemSetName"));
            mappedItemSet.setChampionId(resultSet.getInt("championId"));

            return mappedItemSet;
        }
    }

    private class ItemSetIdMapper implements RowMapper<Integer>{
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("itemSetId");
        }
    }
}
