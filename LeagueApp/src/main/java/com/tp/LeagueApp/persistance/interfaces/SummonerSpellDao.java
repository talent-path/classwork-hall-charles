package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.models.SummonerSpell;

import java.util.List;

public interface SummonerSpellDao {
    List<SummonerSpell> getAllSummonerSpells();
    SummonerSpell getSummonerSpellByName(String summonerSpellName);
}
