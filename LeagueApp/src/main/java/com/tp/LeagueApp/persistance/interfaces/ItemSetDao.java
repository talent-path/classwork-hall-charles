package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.*;
import com.tp.LeagueApp.models.ItemSet;

import java.util.List;

public interface ItemSetDao {

    //CREATE
    ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException, InvalidItemException, EmptyItemListException;

    //READ
    List<ItemSet> getAllItemSets();
    ItemSet getItemSetByName(String itemSetName) throws NullNameException;
    ItemSet getItemSetById(Integer itemSetId) throws NullIdException;

    //UPDATE
    void updateItemSet(ItemSet toUpdate) throws NullSetException, NullIdException;

    //DELETE
    void deleteItemSet(String toDelete) throws NullNameException;
    void deleteItemSetById(Integer toDeleteId) throws NullIdException;


}
