package com.tp.diceroller.services;

import org.springframework.stereotype.Service;

import java.util.Random;

//The service layer contains most of the logic of the project
@Service
public class RNG {

    static Random rng = new Random();

    public static int rollDice(int sideOfDice) {
        return rng.nextInt(sideOfDice) + 1;
    }
}
