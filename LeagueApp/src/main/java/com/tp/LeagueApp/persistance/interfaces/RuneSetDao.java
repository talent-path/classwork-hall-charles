package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.*;
import com.tp.LeagueApp.models.RuneSet;

import java.util.List;

public interface RuneSetDao {

    //CREATE
    RuneSet createNewRuneSet(RuneSet toAdd) throws NullSetException, EmptyItemListException, InvalidRuneException;

    //READ
    List<RuneSet> getAllRuneSets();
    RuneSet getRuneSetByName(String runeSetName) throws NullNameException;
    RuneSet getRuneSetById(Integer runeSetId) throws NullIdException;

    //UPDATE
    void updateRuneSet(RuneSet toUpdate) throws NullSetException, NullIdException;

    //CREATE
    void deleteRuneSet(String toDelete) throws NullNameException;

    void deleteRuneSetById(Integer toDeleteId) throws NullIdException;
}
