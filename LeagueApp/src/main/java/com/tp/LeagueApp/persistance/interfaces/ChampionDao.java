package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.models.Item;

import java.util.List;

public interface ChampionDao {

    //CREATE

    //READ
    List<Champion> getAllChampions();
    Champion getChampionByName(String championName);
    //UPDATE

    //DELETE
}
