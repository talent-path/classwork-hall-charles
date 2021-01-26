package com.tp.diceroller.controllers;

import com.tp.diceroller.services.RNG;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

//Tells Spring that this controller is going to speak to the outside world
//And that we are going to use the REST convention.
//Look into MVC

//Controllers depend on services (service object) to operate
//We will do this using Spring dependency injection and @Autowired
@RestController
public class DiceController {

    //Most common request is a GET request
    //Everytime your browser goes to a URL, you are creating a GET request

    //Handler for our GET request
    //We also need to tell it what URL we want to handle for
    @GetMapping("/helloworld")
    public String helloWorld() {
        return "Hello World!";
    }

    @GetMapping("/sixsides")
    public int sixSides() {
        return RNG.rollDice(6);
    }

    @GetMapping("/twentysides")
    public int twentySides() {
        return RNG.rollDice(20);
    }

    //The initial code for this will produce a null pointer exception
    //To handle this, we need to get a query parameter (which is the the URL)
    //To do this, we append ?n=8 to the end of localhost:8080/nsides.
    @GetMapping("/nsides")
    public int nSides(Integer n) {
        return RNG.rollDice(n);
    }

    //The it says to look in the path for a variable with the same variable name
    //and to fill in that variable into the variable n.
    //So now in the URL, we can add nsides/100 or nsides/10000 etc.
    @GetMapping("/nsides/{n}")
    public int nSidesPathVariable(@PathVariable Integer n) {
        return RNG.rollDice(n);
    }
}
