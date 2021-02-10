package com.tp.LeagueApp.services;

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
    public List<Champion> getAllChampions() {
        return championDao.getAllChampions();
    }

    public Champion getChampionByName(String championName) {
        return championDao.getChampionByName(championName);
    }

    public List<Item> getAllItems() {
        return itemDao.getAllItems();
    }

    public Item getItemByName(String itemName) {
        return itemDao.getItemByName(itemName);
    }

    public List<Rune> getAllRunes() {
        return runeDao.getAllRunes();
    }

    public Rune getRuneByName(String runeName) {
        return runeDao.getRuneByName(runeName);
    }

    public List<SummonerSpell> getAllSummonerSpells() {
        return summonerSpellDao.getAllSummonerSpells();
    }

    public SummonerSpell getSummonerSpellByName(String summonerSpellName) {
        return summonerSpellDao.getSummonerSpellByName(summonerSpellName);
    }


    //Various Sets methods
    public List<ItemSet> getAllItemSets() {
        return itemSetDao.getAllItemSets();
    }

    public ItemSet getItemSetByName(String itemSetName) {
        return itemSetDao.getItemSetByName(itemSetName);
    }

    public ItemSet createNewItemSet(ItemSet toAdd) {
        return itemSetDao.createNewItemSet(toAdd);
    }

    public List<RuneSet> getAllRuneSets() {
        return runeSetDao.getAllRuneSets();
    }

    public RuneSet getRuneSetByName(String runeSetName) {
        return runeSetDao.getRuneSetByName(runeSetName);
    }

    public RuneSet createNewRuneSet(RuneSet toAdd) {
        return runeSetDao.createNewRuneSet(toAdd);
    }

    public List<SummonerSpellSet> getAllSummonerSpellSets() {
        return summonerSpellSetDao.getAllSummonerSpellSets();
    }

    public SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName) {
        return summonerSpellSetDao.getSummonerSpellSetByName(summonerSpellSetName);
    }


}
