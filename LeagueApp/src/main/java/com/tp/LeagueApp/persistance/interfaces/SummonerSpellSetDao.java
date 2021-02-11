package com.tp.LeagueApp.persistance.interfaces;


import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.models.SummonerSpellSet;

import java.util.List;

public interface SummonerSpellSetDao {

    //CREATE
    SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) throws NullSetException;

    //READ
    List<SummonerSpellSet> getAllSummonerSpellSets();
    SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName)throws NullNameException;

    //UPDATE
    void updateSummonerSpellSet(SummonerSpellSet toUpdate) throws NullSetException, NullIdException;

    //DELETE
    void deleteSummonerSpellSet(String toDelete) throws NullNameException;

}
