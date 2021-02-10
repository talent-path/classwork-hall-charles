package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.services.LeagueAppService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class RuneSetController {

    @Autowired
    LeagueAppService service;

    @GetMapping("/runeSets")
    public ResponseEntity getAllRuneSets() {
        List<RuneSet> toReturn = service.getAllRuneSets();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/runeSets/{runeSetName}")
    public ResponseEntity getRuneSetsByName(@PathVariable String runeSetName) {
        RuneSet toReturn = new RuneSet();
        try {
            toReturn = service.getRuneSetByName(runeSetName);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }
}
