package com.tp.LeagueApp.services;

import com.tp.LeagueApp.exceptions.InvalidItemException;
import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.*;
import com.tp.LeagueApp.persistance.interfaces.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class LeagueAppService {

    @Autowired
    ChampionDao championDao;

    @Autowired
    ItemDao itemDao;

    @Autowired
    RuneDao runeDao;

    @Autowired
    SummonerSpellDao summonerSpellDao;

    @Autowired
    ItemSetDao itemSetDao;

    @Autowired
    RuneSetDao runeSetDao;

    @Autowired
    SummonerSpellSetDao summonerSpellSetDao;

    //Base component methods
    //Champions
    public List<Champion> getAllChampions() {
        return championDao.getAllChampions();
    }

    public Champion getChampionByName(String championName) throws NullNameException {
        return championDao.getChampionByName(championName);
    }

    public Champion getChampionById(Integer championId) throws NullIdException {
        return championDao.getChampionById(championId);
    }

    //Items
    public List<Item> getAllItems() {
        return itemDao.getAllItems();
    }

    public Item getItemByName(String itemName) throws NullNameException {
        return itemDao.getItemByName(itemName);
    }

    public Item getItemById(Integer itemId) throws NullIdException {
        return itemDao.getItemById(itemId);
    }

    //Runes
    public List<Rune> getAllRunes() {
        return runeDao.getAllRunes();
    }

    public Rune getRuneByName(String runeName) throws NullNameException {
        return runeDao.getRuneByName(runeName);
    }

    public Rune getRuneById(Integer runeId) throws NullIdException {
        return runeDao.getRuneById(runeId);
    }

    //Summoner Spells
    public List<SummonerSpell> getAllSummonerSpells() {
        return summonerSpellDao.getAllSummonerSpells();
    }

    public SummonerSpell getSummonerSpellByName(String summonerSpellName) throws NullNameException {
        return summonerSpellDao.getSummonerSpellByName(summonerSpellName);
    }

    public SummonerSpell getSummonerSpellById(Integer summonerSpellId) throws NullIdException {
        return summonerSpellDao.getSummonerSpellById(summonerSpellId);
    }

    //Various Sets methods
    //Item Sets
    public ItemSet createNewItemSet(ItemSet toAdd) throws NullSetException, InvalidItemException {
        return itemSetDao.createNewItemSet(toAdd);
    }

    public List<ItemSet> getAllItemSets() {
        return itemSetDao.getAllItemSets();
    }

    public ItemSet getItemSetByName(String itemSetName) throws NullNameException {
        return itemSetDao.getItemSetByName(itemSetName);
    }

    public ItemSet getItemSetById(Integer itemSetId) throws NullIdException {
        return itemSetDao.getItemSetById(itemSetId);
    }

    public void updateItemSet(ItemSet toUpdate) throws NullSetException, NullIdException {
        itemSetDao.updateItemSet(toUpdate);
    }

    public void deleteItemSet(String toDelete) throws NullNameException {
        itemSetDao.deleteItemSet(toDelete);
    }

    public void deleteItemSetById(Integer toDeleteId) throws NullIdException {
        itemSetDao.deleteItemSetById(toDeleteId);
    }

    //Rune Sets
    public RuneSet createNewRuneSet(RuneSet toAdd) throws NullSetException {
        return runeSetDao.createNewRuneSet(toAdd);
    }

    public List<RuneSet> getAllRuneSets() {
        return runeSetDao.getAllRuneSets();
    }

    public RuneSet getRuneSetByName(String runeSetName) throws NullNameException {
        return runeSetDao.getRuneSetByName(runeSetName);
    }

    public RuneSet getRuneSetById(Integer runeSetId) throws NullIdException {
        return runeSetDao.getRuneSetById(runeSetId);
    }

    public void updateRuneSet(RuneSet toUpdate) throws NullSetException, NullIdException {
        runeSetDao.updateRuneSet(toUpdate);
    }

    public void deleteRuneSet(String toDelete) throws NullNameException {
        runeSetDao.deleteRuneSet(toDelete);
    }

    public void deleteRuneSetById(Integer toDeleteId) throws NullIdException {
        runeSetDao.deleteRuneSetById(toDeleteId);
    }

    //Summoner Spell Sets
    public SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) throws NullSetException {
        return summonerSpellSetDao.createNewSummonerSpellSet(toAdd);
    }

    public List<SummonerSpellSet> getAllSummonerSpellSets() {
        return summonerSpellSetDao.getAllSummonerSpellSets();
    }

    public SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName) throws NullNameException {
        return summonerSpellSetDao.getSummonerSpellSetByName(summonerSpellSetName);
    }

    public SummonerSpellSet getSummonerSpellSetById(Integer summonerSpellSetId) throws NullIdException {
        return summonerSpellSetDao.getSummonerSpellSetById(summonerSpellSetId);
    }

    public void updateSummonerSpellSet(SummonerSpellSet toUpdate) throws NullSetException, NullIdException {
        summonerSpellSetDao.updateSummonerSpellSet(toUpdate);
    }

    public void deleteSummonerSpellSet(String toDelete) throws NullNameException {
        summonerSpellSetDao.deleteSummonerSpellSet(toDelete);
    }

    public void deleteSummonerSpellSetById(Integer toDeleteId) throws NullIdException {
        summonerSpellSetDao.deleteSummonerSpellSetById(toDeleteId);
    }

}
