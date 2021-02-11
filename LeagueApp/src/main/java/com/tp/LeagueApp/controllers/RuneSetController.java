package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.models.RuneSet;
import com.tp.LeagueApp.services.LeagueAppService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class RuneSetController {

    @Autowired
    LeagueAppService service;

    @PostMapping("/new/runeSet")
    public ResponseEntity createNewRuneSet(@RequestBody RuneSet toAdd) {
        RuneSet toReturn = null;
        try {
            toReturn = service.createNewRuneSet(toAdd);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

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

    @PutMapping("/update/runeSet")
    public String updateRuneSet(@RequestBody RuneSet toUpdate) {
        try {
            service.updateRuneSet(toUpdate);
            return "Rune Set " + toUpdate.getRuneSetId() + " successfully updated.";
        }
        catch(Exception e) {
            return e.getMessage();
        }
    }
}
