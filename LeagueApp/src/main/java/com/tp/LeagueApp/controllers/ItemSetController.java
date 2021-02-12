package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.exceptions.*;
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
        catch(EmptyItemListException | NullSetException | InvalidItemException e) {
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

    @GetMapping("/itemSets/name/{itemSetName}")
    public ResponseEntity getItemSetsByName(@PathVariable String itemSetName) {
        ItemSet toReturn = new ItemSet();
        try {
            toReturn = service.getItemSetByName(itemSetName);
        }
        catch(NullNameException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/itemSets/id/{itemSetId}")
    public ResponseEntity getItemSetsById(@PathVariable Integer itemSetId) {
        ItemSet toReturn = new ItemSet();
        try {
            toReturn = service.getItemSetById(itemSetId);
        }
        catch(NullIdException | InvalidSetException e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

    //UPDATE
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

    //DELETE
    @DeleteMapping("/delete/itemSet/name/{itemSetName}")
    public String deleteItemSet(@PathVariable String itemSetName) {
        try {
            service.deleteItemSet(itemSetName);
            return "Item Set " + itemSetName + " successfully deleted.";
        }
        catch(NullNameException e) {
            return e.getMessage();
        }
    }

    @DeleteMapping("/delete/itemSet/id/{itemSetId}")
    public String deleteItemSetById(@PathVariable Integer itemSetId) {
        try {
            service.deleteItemSetById(itemSetId);
            return "Item Set " + itemSetId + " successfully deleted.";
        }
        catch(NullIdException | InvalidSetException e) {
            return e.getMessage();
        }
    }

}
