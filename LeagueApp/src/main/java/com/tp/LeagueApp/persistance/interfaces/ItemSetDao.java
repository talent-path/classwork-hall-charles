package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;

import java.util.List;

public interface ItemSetDao {
    ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException;
    List<ItemSet> getAllItemSets();
    ItemSet getItemSetByName(String itemSetName) throws NullNameException;
    void updateItemSet(ItemSet toUpdate) throws NullSetException;
}
