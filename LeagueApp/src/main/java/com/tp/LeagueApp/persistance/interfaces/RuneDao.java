package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.models.Rune;

import java.util.List;

public interface RuneDao {

    List<Rune> getAllRunes();
    Rune getRuneByName(String runeName);

}
