package com.tp.LeagueApp.services;

import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.Rune;
import com.tp.LeagueApp.persistance.ChampionDao;
import com.tp.LeagueApp.persistance.ItemDao;
import com.tp.LeagueApp.persistance.PostgresItemSetDao;
import com.tp.LeagueApp.persistance.RuneDao;
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
    PostgresItemSetDao itemSetDao;

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

    public List<ItemSet> getAllItemSets() {
        return itemSetDao.getAllItemSets();
    }

    public ItemSet getItemSetByName(String itemSetName) {
        return itemSetDao.getItemSetByName(itemSetName);
    }
}
