package com.tp.LeagueApp.controllers;

import com.tp.LeagueApp.models.Champion;
import com.tp.LeagueApp.models.Item;
import com.tp.LeagueApp.models.ItemSet;
import com.tp.LeagueApp.services.LeagueAppService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class ItemController {

    @Autowired
    LeagueAppService service;

    @GetMapping("/items")
    public ResponseEntity getAllItemSets() {
        List<Item> toReturn = service.getAllItems();

        return ResponseEntity.ok(toReturn);
    }

    @GetMapping("/items/{itemName}")
    public ResponseEntity getItemByName(@PathVariable String itemName) {
        Item toReturn = new Item();
        try {
            toReturn = service.getItemByName(itemName);
        }
        catch(Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(e.getMessage());
        }

        return ResponseEntity.ok(toReturn);
    }

}