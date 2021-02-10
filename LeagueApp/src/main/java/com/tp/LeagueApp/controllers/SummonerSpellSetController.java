package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.models.SummonerSpellSet;
import com.tp.LeagueApp.services.LeagueAppService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class SummonerSpellSetController {
    @Autowired
    LeagueAppService service;

    //User summonerSpellSetName in JSON request!!
    @PostMapping("/new/summonerSpellSet")
    public ResponseEntity createNewRuneSet(@RequestBody SummonerSpellSet toAdd) {
        SummonerSpellSet toReturn = null;
        try {
            toReturn = service.createNewSummonerSpellSet(toAdd);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/summonerSpellSets")
    public ResponseEntity getAllSummonerSpellSets() {
        List<SummonerSpellSet> toReturn = service.getAllSummonerSpellSets();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/summonerSpellSets/{summonerSpellSetName}")
    public ResponseEntity getSummonerSpellSetsByName(@PathVariable String summonerSpellSetName) {
        SummonerSpellSet toReturn = new SummonerSpellSet();
        try {
            toReturn = service.getSummonerSpellSetByName(summonerSpellSetName);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }
}
