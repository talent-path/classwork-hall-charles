package com.tp.LeagueApp.persistance.interfaces;

import com.tp.LeagueApp.exceptions.NullNameException;
import com.tp.LeagueApp.models.Rune;

import java.util.List;

public interface RuneDao {

    //READ
    List<Rune> getAllRunes();
    Rune getRuneByName(String runeName) throws NullNameException;

}
