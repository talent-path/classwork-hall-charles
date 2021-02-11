package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.exceptions.NullSetException;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.services.LeagueAppService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ItemSetController {

    @Autowired
    LeagueAppService service;

    //CREATE
    @PostMapping("/new/itemSet")
    public ResponseEntity createNewItemSet(@RequestBody ItemSet toAdd) {
        ItemSet toReturn = null;
        try {
            toReturn = service.createNewItemSet(toAdd);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //READ
    @GetMapping("/itemSets")
    public ResponseEntity getAllItemSets() {
        List<ItemSet> toReturn = service.getAllItemSets();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/itemSets/{itemSetName}")
    public ResponseEntity getItemSetsByName(@PathVariable String itemSetName) {
        ItemSet toReturn = new ItemSet();
        try {
            toReturn = service.getItemSetByName(itemSetName);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @PutMapping("/update/itemSet")
    public String updateItemSet(@RequestBody ItemSet toUpdate) {
        try {
            service.updateItemSet(toUpdate);
            return "Item Set " + toUpdate.getItemSetId() + " successfully updated.";
        }
        catch(Exception e) {
            return e.getMessage();
        }
    }

}
