package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.models.ItemSet;

import java.util.List;

public interface ItemSetDao {
    List<ItemSet> getAllItemSets();
    ItemSet getItemSetByName(String itemSetName);
    ItemSet createNewItemSet(ItemSet toAdd);
}
