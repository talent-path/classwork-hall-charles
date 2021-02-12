package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.exceptions.NullIdException;
import com.tp.LeagueApp.exceptions.NullNameException;
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

    //CREATE
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

    //READ
    @GetMapping("/runeSets")
    public ResponseEntity getAllRuneSets() {
        List<RuneSet> toReturn = service.getAllRuneSets();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/runeSets/name/{runeSetName}")
    public ResponseEntity getRuneSetsByName(@PathVariable String runeSetName) {
        RuneSet toReturn = new RuneSet();
        try {
            toReturn = service.getRuneSetByName(runeSetName);
        }
        catch(NullNameException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/runeSets/id/{runeSetId}")
    public ResponseEntity getRuneSetsById(@PathVariable Integer runeSetId) {
        RuneSet toReturn = new RuneSet();
        try {
            toReturn = service.getRuneSetById(runeSetId);
        }
        catch(NullIdException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //UPDATE
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

    //DELETE
    @DeleteMapping("/delete/runeSet/name/{runeSetName}")
    public String deleteRuneSet(@PathVariable String runeSetName) {
        try {
            service.deleteRuneSet(runeSetName);
            return "Rune Set " + runeSetName + " successfully deleted.";
        }
        catch(NullNameException e) {
            return e.getMessage();
        }
    }

    @DeleteMapping("/delete/runeSet/id/{runeSetId}")
    public String deleteRuneSet(@PathVariable Integer runeSetId) {
        try {
            service.deleteRuneSetById(runeSetId);
            return "Rune Set " + runeSetId + " successfully deleted.";
        }
        catch(NullIdException e) {
            return e.getMessage();
        }
    }
}
