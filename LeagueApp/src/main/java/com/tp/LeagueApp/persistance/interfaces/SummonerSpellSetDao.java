package com.tp.LeagueApp.persistance.interfaces;


import com.tp.LeagueApp.exceptions.*;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.models.SummonerSpellSet;

import java.util.List;

public interface SummonerSpellSetDao {

    //CREATE
    SummonerSpellSet createNewSummonerSpellSet(SummonerSpellSet toAdd) throws NullSetException, EmptySummonerSpellListException, InvalidSummonerSpellException;

    //READ
    List<SummonerSpellSet> getAllSummonerSpellSets();
    SummonerSpellSet getSummonerSpellSetByName(String summonerSpellSetName)throws NullNameException;
    SummonerSpellSet getSummonerSpellSetById(Integer summonerSpellSetId)throws NullIdException;

    //UPDATE
    void updateSummonerSpellSet(SummonerSpellSet toUpdate) throws NullSetException, NullIdException, InvalidSetException;

    //DELETE
    void deleteSummonerSpellSet(String toDelete) throws NullNameException;

    void deleteSummonerSpellSetById(Integer toDeleteId) throws NullIdException, InvalidSetException;
}
