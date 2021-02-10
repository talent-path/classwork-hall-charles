package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;

import java.util.List;

public interface ItemSetDao {
    List<ItemSet> getAllItemSets();
    ItemSet getItemSetByName(String itemSetName) throws NullNameException;
    ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException;
}
