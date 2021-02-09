package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.models.Item;

import java.util.List;

public interface ItemDao {

    List<Item> getAllItems();
    Item getItemByName(String itemName);
}
