package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.persistance.interfaces.ItemSetDao;
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
    public ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException {

        if(toAdd == null)
            throw new NullSetException("ERROR: Tried to create a null item set.");

        Integer itemSetId = template.queryForObject("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (?, ?) RETURNING \"itemSetId\";",
                new ItemSetIdMapper(),
                toAdd.getItemSetName(),
                toAdd.getChampionId()
        );

        toAdd.setItemSetId(itemSetId);

        return toAdd;
    }

    @Override
    public List<ItemSet> getAllItemSets() {
        List<ItemSet> allItemSets = template.query("select * from \"ItemSets\"", new PostgresItemSetDao.ItemSetMapper());

        return allItemSets;
    }

    @Override
    public ItemSet getItemSetByName(String itemSetName) throws NullNameException {

        if(itemSetName == null)
            throw new NullNameException("ERROR: Tried to get an item set with a null name.");

        List<ItemSet> toReturn = template.query("select * from \"ItemSets\" where \"itemSetName\" = ?;", new PostgresItemSetDao.ItemSetMapper(), itemSetName);

        return toReturn.get(0);
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
