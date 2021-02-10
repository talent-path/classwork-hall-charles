package com.tp.LeagueApp.persistance.interfaces;


import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.SummonerSpellSet;

import java.util.List;

public interface SummonerSpellSetDao {
    List<SummonerSpellSet> getAllSummonerSpellSets();
    SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName);
    SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) throws NullSetException;
}
