package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;

import java.util.List;

public interface RuneSetDao {
    List<RuneSet> getAllRuneSets();
    RuneSet getRuneSetByName(String runeSetName);
    RuneSet createNewRuneSet(RuneSet toAdd) throws NullSetException;
}
