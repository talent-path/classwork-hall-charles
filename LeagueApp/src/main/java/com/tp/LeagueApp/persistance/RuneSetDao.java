package com.tp.LeagueApp.persistance;

import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;

import java.util.List;

public interface RuneSetDao {
    List<RuneSet> getAllRuneSets();
    RuneSet getRuneSetByName(String runeSetName);
}
