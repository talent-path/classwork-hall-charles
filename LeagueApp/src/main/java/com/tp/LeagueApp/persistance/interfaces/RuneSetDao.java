package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;

import java.util.List;

public interface RuneSetDao {

    //CREATE
    RuneSet createNewRuneSet(RuneSet toAdd) throws NullSetException;

    //READ
    List<RuneSet> getAllRuneSets();
    RuneSet getRuneSetByName(String runeSetName) throws NullNameException;

    //UPDATE
    void updateRuneSet(RuneSet toUpdate) throws NullSetException, NullIdException;

    //CREATE
    void deleteRuneSet(String toDelete) throws NullNameException;

}
