package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.services.LeagueAppService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class ChampionController {

    @Autowired
    LeagueAppService service;

    @GetMapping("/champions")
    public ResponseEntity getAllChampions() {
        List<Champion> toReturn = service.getAllChampions();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/champions/{championName}")
    public ResponseEntity getChampionByName(@PathVariable String championName) {
        Champion toReturn = new Champion();
        try {
            toReturn = service.getChampionByName(championName);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

}
