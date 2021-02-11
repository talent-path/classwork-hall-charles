package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.InvalidItemException;
import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;

import java.util.List;

public interface ItemSetDao {

    //CREATE
    ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException, InvalidItemException;

    //READ
    List<ItemSet> getAllItemSets();
    ItemSet getItemSetByName(String itemSetName) throws NullNameException;

    //UPDATE
    void updateItemSet(ItemSet toUpdate) throws NullSetException, NullIdException;

    //DELETE
    void deleteItemSet(String toDelete) throws NullNameException;

}
