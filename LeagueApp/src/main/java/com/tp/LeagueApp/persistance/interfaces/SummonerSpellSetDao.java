package com.tp.LeagueApp.persistance.interfaces;


import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.SummonerSpellSet;

import java.util.List;

public interface SummonerSpellSetDao {
    SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) throws NullSetException;
    List<SummonerSpellSet> getAllSummonerSpellSets();
    SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName)throws NullNameException;
}
