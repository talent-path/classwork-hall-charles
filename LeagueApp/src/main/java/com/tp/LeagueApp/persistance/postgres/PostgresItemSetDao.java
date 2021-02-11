package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.InvalidItemException;
import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.Item;
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

    //CREATE
    @Override
    public ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException, InvalidItemException {

        if(toAdd == null)
            throw new NullSetException("ERROR: Tried to create a null item set.");

        //TODO Figure out proper way to check if items exist.
//        for(Item toCheck : toAdd.getItemList()) {
//            List<Integer> returnedId = template.query("select \"itemId\" from \"Items\" where \"itemName\" = ?;",
//                    new ItemSetIdMapper(),
//                    toCheck.getItemName());
//
//            if(returnedId.get(0) == null)
//                throw new InvalidItemException("ERROR: Tried to create an item set with non-existent items.");
//
//        }

        Integer itemSetId = template.queryForObject("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (?, ?) RETURNING \"itemSetId\";",
                new ItemSetIdMapper(),
                toAdd.getItemSetName(),
                toAdd.getChampionId()
        );

        toAdd.setItemSetId(itemSetId);

        return toAdd;
    }

    //READ
    @Override
    public List<ItemSet> getAllItemSets() {
        List<ItemSet> allItemSets = template.query("select * from \"ItemSets\"",
                new PostgresItemSetDao.ItemSetMapper());

        return allItemSets;
    }

    @Override
    public ItemSet getItemSetByName(String itemSetName) throws NullNameException {

        if(itemSetName == null)
            throw new NullNameException("ERROR: Tried to get an item set with a null name.");

        List<ItemSet> toReturn = template.query("select * from \"ItemSets\" where \"itemSetName\" = ?;",
                new PostgresItemSetDao.ItemSetMapper(), itemSetName);

        return toReturn.get(0);
    }

    //UPDATE
    @Override
    public void updateItemSet(ItemSet toUpdate) throws NullSetException, NullIdException {

        if(toUpdate == null)
            throw new NullSetException("ERROR: Tried to update item set with a null item set.");
        if(toUpdate.getItemSetId() == null)
            throw new NullIdException("ERROR: Tried to update an item set with a null id.");

        template.update("update \"ItemSets\" set \"itemSetName\" = ?, \"championId\" = ? where \"itemSetId\" = ?",
                toUpdate.getItemSetName(), toUpdate.getChampionId(), toUpdate.getItemSetId());

    }

    //DELETE
    @Override
    public void deleteItemSet(String toDelete) throws NullNameException {

        if(toDelete == null)
            throw new NullNameException("ERROR: Tried to delete an item set with a null name.");

        template.update("delete from \"ItemSets\" where \"itemSetName\" = ?;", toDelete);
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
