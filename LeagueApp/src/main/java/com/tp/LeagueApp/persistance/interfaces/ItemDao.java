package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Item;

import java.util.List;

public interface ItemDao {

    List<Item> getAllItems();
    Item getItemByName(String itemName) throws NullNameException;
}
