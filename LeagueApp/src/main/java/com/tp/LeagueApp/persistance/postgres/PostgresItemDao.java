package com.tp.LeagueApp.persistance.postgres;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.persistance.interfaces.ItemDao;
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
public class PostgresItemDao implements ItemDao {
    @Autowired
    JdbcTemplate template;

    //READ
    @Override
    public List<Item> getAllItems() {
        List<Item> allItems = template.query("select * from \"Items\"", new PostgresItemDao.ItemMapper());

        return allItems;
    }

    @Override
    public Item getItemByName(String itemName) throws NullNameException {

        if(itemName == null)
            throw new NullNameException("ERROR: Tried to get an item with a null name.");

        List<Item> toReturn = template.query("select * from \"Items\" where \"itemName\" = ?;", new PostgresItemDao.ItemMapper(), itemName);

        return toReturn.get(0);
    }

    private class ItemMapper implements RowMapper<Item> {

        public Item mapRow(ResultSet resultSet, int i) throws SQLException {
            Item mappedItem = new Item();
            mappedItem.setItemId(resultSet.getInt("itemId"));
            mappedItem.setItemName(resultSet.getString("itemName"));
            mappedItem.setItemDescription(resultSet.getString("itemDescription"));
            mappedItem.setItemCost(resultSet.getInt("itemCost"));

            return mappedItem;
        }
    }
}
