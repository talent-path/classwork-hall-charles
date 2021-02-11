package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;

import java.util.List;

public interface RuneSetDao {
    RuneSet createNewRuneSet(RuneSet toAdd) throws NullSetException;
    List<RuneSet> getAllRuneSets();
    RuneSet getRuneSetByName(String runeSetName) throws NullNameException;
    void updateRuneSet(RuneSet toUpdate) throws NullSetException;
    void deleteRuneSet(String toDelete) throws NullNameException;
}
