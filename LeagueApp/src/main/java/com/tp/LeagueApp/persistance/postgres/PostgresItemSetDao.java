package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.*;
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
    public ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException, InvalidItemException, EmptyItemListException {

        if(toAdd == null)
            throw new NullSetException("ERROR: Tried to create a null item set.");
        if(toAdd.getItemIdList().size() == 0)
            throw new EmptyItemListException("ERROR: Empty item list.");

        //Add validate items
        if(!validateItemList(toAdd.getItemIdList()))
            throw new InvalidItemException("Item in list is not valid.");

        Integer itemSetId = template.queryForObject("insert into \"ItemSets\" (\"itemSetName\", \"championId\") values (?, ?) RETURNING \"itemSetId\";",
                new ItemSetIdMapper(),
                toAdd.getItemSetName(),
                toAdd.getChampionId()
        );

        //Add insert into bridge
        for(Integer itemIdToAdd : toAdd.getItemIdList()) {
            template.update("insert into \"ItemSetItems\" (\"itemSetId\", \"itemId\") values ('"+itemSetId+"', '"+itemIdToAdd+"')");
        }

        toAdd.setItemSetId(itemSetId);

        return toAdd;
    }

    private boolean validateItemList(List<Integer> toCheck) {
        boolean equal = true;

        Integer queryCount = 0;

        for(Integer toValidate : toCheck) {
            queryCount += template.queryForObject("select COUNT(*) from \"Items\" where \"itemId\" in (?)", new ItemSetCountMapper(), toValidate);
        }

        Integer toCheckCount = toCheck.size();

        if(!queryCount.equals(toCheckCount))
            equal = false;

        return equal;
    }

    //READ
    @Override
    public List<ItemSet> getAllItemSets() {
        List<ItemSet> allItemSets = template.query("select * from \"ItemSets\"",
                new PostgresItemSetDao.ItemSetMapper());

        for(ItemSet toGet : allItemSets) {
            List<Integer> itemIds = template.query("select isi.\"itemId\"\n" +
                    "from \"ItemSetItems\" as isi\n" +
                    "where isi.\"itemSetId\" = ?;", new ItemIdMapper(), toGet.getItemSetId());

            toGet.setItemIdList(itemIds);
        }

        return allItemSets;
    }

    private class ItemIdMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("itemId");
        }
    }

    @Override
    public ItemSet getItemSetById(Integer itemSetId) throws NullIdException, InvalidSetException {

        if(itemSetId == null)
            throw new NullIdException("ERROR: Tried to get an item set with a null id.");
        if(!validateItemSetId(itemSetId))
            throw new InvalidSetException("ERROR: Tried to get a set that doesn't exist.");

        List<ItemSet> toReturn = template.query("select * from \"ItemSets\" where \"itemSetId\" = ?;",
                new PostgresItemSetDao.ItemSetMapper(), itemSetId);

        List<Integer> itemIds = template.query("select isi.\"itemId\"\n" +
                "from \"ItemSetItems\" as isi\n" +
                "where isi.\"itemSetId\" = "+itemSetId+";", new ItemIdMapper());

        toReturn.get(0).setItemIdList(itemIds);


        return toReturn.get(0);
    }

    //UPDATE
    @Override
    public void updateItemSet(ItemSet toUpdate) throws NullSetException, NullIdException, InvalidSetException {

        if(toUpdate == null)
            throw new NullSetException("ERROR: Tried to update item set with a null item set.");
        if(toUpdate.getItemSetId() == null)
            throw new NullIdException("ERROR: Tried to update an item set with a null id.");
        if(!validateItemSetId(toUpdate.getItemSetId()))
            throw new InvalidSetException("ERROR: Tried to delete a set that doesn't exist.");

        template.update("update \"ItemSets\" set \"itemSetName\" = ?, \"championId\" = ? where \"itemSetId\" = ?",
                toUpdate.getItemSetName(), toUpdate.getChampionId(), toUpdate.getItemSetId());

    }

    //DELETE
    @Override
    public void deleteItemSetById(Integer toDeleteId) throws NullIdException, InvalidSetException {
        if(toDeleteId == null)
            throw new NullIdException("ERROR: Tried to delete an item set with a null id.");
        if(!validateItemSetId(toDeleteId))
            throw new InvalidSetException("ERROR: Tried to delete a set that doesn't exist.");

        template.update("delete from \"ItemSetItems\" where \"itemSetId\" = ?;", toDeleteId);
        template.update("delete from \"ItemSets\" where \"itemSetId\" = ?;", toDeleteId);
    }

    private boolean validateItemSetId(Integer toValidate) {

        boolean exists = true;

        Integer returnCount = template.queryForObject("select COUNT(*) from \"ItemSets\" where \"itemSetId\" in (?)", new ItemSetCountMapper(), toValidate);

        Integer zero = 0;

        if(returnCount.equals(zero))
            exists = false;

        return exists;
    }

    //MAPPERS

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

    private class ItemSetIdMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("itemSetId");
        }
    }

    private class ItemSetCountMapper implements RowMapper<Integer> {

        @Override
        public Integer mapRow(ResultSet resultSet, int i) throws SQLException {
            return resultSet.getInt("count");
        }
    }
}
