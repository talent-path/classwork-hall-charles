//we're defining a "class" to represent different playing cards
//each "instance" of this class will be an object of the PlayingCard type

import java.util.HashMap;
import java.util.Map;

public class Card {

    //field variables
    //variables which exist per-instance (so one PlayingCard may have different values for these variables
    //                                      from the next)

    Suit cardSuit;
    Value cardValue;

    static Suit[] suits = { Suit.SPADES, Suit.DIAMONDS, Suit.CLUBS, Suit.HEARTS };
    static Value[] values = {
            Value.TWO,
            Value.THREE,
            Value.FOUR,
            Value.FIVE,
            Value.SIX,
            Value.SEVEN,
            Value.EIGHT,
            Value.NINE,
            Value.TEN,
            Value.JACK,
            Value.QUEEN,
            Value.KING,
            Value.ACE
    };


    //constructors are special methods that run as soon as the object is instantiated (when we use the new keyword)
    //constructors don't have a return type and are named the same thing as the class
    public Card(Value cardValue, Suit cardSuit ){
        //we store the incoming data into our field variables
        //without this step, we lose data (the arguments passed in are not saved by default)
        this.cardValue = cardValue;
        this.cardSuit = cardSuit;
    }


    //the values are 0-51
    //the suit is value%4            (0-spades, 1-diamonds, 2-clubs, 3-hearts)
    //the card is value/4 + 2       J = 11, Q = 12, K = 13, A = 14
    public Card(int cardNum ){
        //with the arrays, we can just jump to the right enum value
        this( values[cardNum / 4], suits[cardNum % 4]);

    }

    public Card(char cardValue, char cardSuit) {

    }


    //accessor functions
    //"getter" and "setter"
    public Suit getCardSuit(){
        return cardSuit;
    }

    public void setCardSuit( Suit cardSuit ){
        //"this" refers to the current instance
        //normally we don't need this keyword (as in the getter)
        //but if we have another variable with the same name
        //it's the only way to access the field variable
        this.cardSuit = cardSuit;
    }

    public Value getCardValue(){
        return cardValue;
    }

    public void setCardValue( Value cardValue ){
        this.cardValue = cardValue;
    }




}
