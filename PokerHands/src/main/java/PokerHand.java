import java.util.HashMap;
import java.util.Map;

/**
 * This is the main class we will be implementing. It will
 * check which card has the higher ranking of cards.
 */
public class PokerHand {
    Card[] cards;

    static Map<Character, Integer> faceValue = new HashMap<>() {{
        put('2', 0);
        put('3', 1);
        put('4', 2);
        put('5', 3);
        put('6', 4);
        put('7', 5);
        put('8', 6);
        put('9', 7);
        put('T', 8);
        put('J', 9);
        put('Q', 10);
        put('K', 11);
        put('A', 12);
    }};

    static Map<Character, Integer> suit = new HashMap<>() {{
        put('S', 0);
        put('D', 1);
        put('C', 2);
        put('H', 3);
    }};

    /**
     * Constructor for Poker Hand.
     * @param cards
     */
    public PokerHand( Card[] cards ) {
        this.cards = cards;
        sortCards();
    }

    /**
     * This will gives us a naive approach to sorting the cards in our hands.
     */
    private void sortCards() {

        //bubble sort
        boolean sorted = false;

        while( !sorted ){

            sorted = true;
            for( int i = 0; i < cards.length - 1; i++){
                //does the element at i need to be flipped with the element at i + 1?
                if( (cards[i].getCardValue().value < cards[i+1].getCardValue().value) ||

                        (cards[i].getCardValue().value == cards[i+1].getCardValue().value
                                && cards[i].getCardSuit().value < cards[i+1].getCardSuit().value
                        )
                ){
                    //we need to swap elements at i and i + 1
                    //it also means we found elements out of order
                    sorted = false;
                    Card temp = cards[i+1];
                    cards[i+1] = cards[i];
                    cards[i] = temp;
                }
            }

        }

    }

    public Card[] getCards(){
        return cards;
    }

    public int[] getCardsValue() {
        int[] cardsValue = new int[cards.length];

        for(int i = 0; i < cards.length; i++) {
            int value = cards[i].getCardValue().value;
            int suit = cards[i].getCardSuit().value;
            System.out.println("Value: " + value);
            System.out.println("Suit: " + suit);
        }

        return cardsValue;
    }

    public Map<Value, Integer> countFaceValue() {
        Map<Value, Integer> count = new HashMap<>();
        for (Card card : cards)
            count.put(card.getCardValue(), count.getOrDefault(card.getCardValue(), 0) + 1);
        return count;
    }
    public Map<Suit, Integer> countSuite() {
        Map<Suit, Integer> count = new HashMap<>();
        for (Card card : cards)
            count.put(card.getCardSuit(), count.getOrDefault(card.getCardSuit(), 0) + 1);
        return count;
    }
    // 1 Royal Flush
    public boolean isRoyalFlush() {
        return isStraightFlush() && cards[0].getCardValue() == Value.ACE;
    }
    // 2 Straight Flush
    public boolean isStraightFlush() {
        // if all is the same suit cards[0] && cards[1] && cards[2] && cards[3] && cards[4]
        boolean inSequence = false;
        for (int i = 1; i < 5; i++) {
            if (cards[i - 1].getCardValue().value - 1 == cards[i].getCardValue().value)
                inSequence = true;
            else {
                inSequence = false;
                break;
            }
        }
        boolean sameSuit = false;
        Map<Suit, Integer> mapSuit = this.countSuite();
        for (Suit suit : mapSuit.keySet())
            if (mapSuit.get(suit) == 5) sameSuit = true;
        if (sameSuit && inSequence)
            return true;
        else return false;
    }

    // 3 Four of a Kind
    //if not 4 of a kind, return null
    public Value isFourOfAKindValue() {
        Map<Value, Integer> mapFV = this.countFaceValue();
        for (Value value : mapFV.keySet())
            if (mapFV.get(value) == 4) return value;
        return null;
    }

    // 4 Full House
    public boolean isFullHouse() {
        return isPair() != null && isThreeOfAKindValue() != null;
    }

    // 5 Flush
    public boolean isFlush() {
        // if all is the same suit cards[0] && cards[1] && cards[2] && cards[3] && cards[4]
        boolean inSequence = false;
        for (int i = 1; i < 5; i++) {
            if (cards[i - 1].getCardValue().value - 1 == cards[i].getCardValue().value)
                inSequence = true;
            else {
                inSequence = false;
                break;
            }
        }
        boolean sameSuit = false;
        Map<Suit, Integer> mapSuit = this.countSuite();
        for (Suit suit : mapSuit.keySet())
            if (mapSuit.get(suit) == 5) sameSuit = true;
        if (sameSuit && !inSequence)
            return true;
        else return false;
    }

    // 6 Straight
    //if no straight, return a null
    public Value isStraight() {
        // TODO
        // has to be in a sequence BUT cannot be in the same suite
        boolean isNotSameSuite = false;
        Map<Suit, Integer> mapSuit = this.countSuite();
        for (Suit suit : mapSuit.keySet())
            if (mapSuit.get(suit) > 1) isNotSameSuite = true;
        boolean inSequence = true;
        for (int i = 1; i < 5; i++) {
            if (cards[i - 1].getCardValue().value - 1 == cards[i].getCardValue().value)
                inSequence = true;
            else {
                inSequence = false;
                break;
            }
        }
        if (isNotSameSuite && inSequence)
            return this.cards[0].getCardValue();
        else return null;
    }

    // 7 Three of a Kind
    //should return null if there are really 4
    public Value isThreeOfAKindValue() {

        Map<Value, Integer> mapFV = this.countFaceValue();
        for (Value value : mapFV.keySet())
            if (mapFV.get(value) == 3) return value;
        return null;
    }

    // 8 Two Pair
    //should return null if there are really 3 (or more of the same card)
    public Value isTwoPair() {
        // TODO
        Map<Value, Integer> mapFV = this.countFaceValue();
        Value value1 = null;
        Value value2 = null;
        for (Value value : mapFV.keySet())
            if (mapFV.get(value) == 2)
                if (value1 != null) value2 = value;
                else value1 = value;
        if (value1 == null || value2 == null) return null;
        if (value1.value > value2.value) return value1;
        else if (value1.value < value2.value) return value2;
        return null;
    }

    // 9 Pair
    //should return null when there is only one pair
    public Value isPair() {
        // TODO
        Map<Value, Integer> mapFV = this.countFaceValue();
        for (Value value : mapFV.keySet())
            if (mapFV.get(value) == 2) return value;
        return null;
    }

    // 10 High Card
    public Value isHighCard() {
        return this.cards[0].getCardValue();
    }

    /**
     * compareTo method checks this object with that object
     * and checks if they are equal, or if this is greater
     * than that, or if that is greater than this.
     * @param that
     * @return 0 if tied, -1 if player 1 wins, 1 if player 2 wins
     */
    public int compareTo(PokerHand that) {
        if (this.isRoyalFlush() && !that.isRoyalFlush())
            return -1;
        else if (!this.isRoyalFlush() && that.isRoyalFlush())
            return 1;
        else if (this.isRoyalFlush() && that.isRoyalFlush())
            return 0;
        else if (this.isStraightFlush() && !that.isStraightFlush())
            return -1;
        else if (!this.isStraightFlush() && that.isStraightFlush())
            return 1;
        else if (this.isStraightFlush() && that.isStraightFlush())
            return 0;
        else if (this.isFourOfAKindValue() != null || that.isFourOfAKindValue() != null) {
            if (this.isFourOfAKindValue() == null && that.isFourOfAKindValue() != null)
                return 1;
            else if (this.isFourOfAKindValue() != null && that.isFourOfAKindValue() == null)
                return -1;
            else if (this.isFourOfAKindValue() == that.isFourOfAKindValue())
                return 0;
            else if (this.isFourOfAKindValue().value > that.isFourOfAKindValue().value)
                return -1;
            else if (this.isFourOfAKindValue().value < that.isFourOfAKindValue().value)
                return 1;
        }
        else if (this.isFullHouse() && !that.isFullHouse())
            return -1;
        else if (!this.isFullHouse() && that.isFullHouse())
            return 1;
        else if (this.isFullHouse() && that.isFullHouse())
            return 0;
        else if (this.isFlush() && !that.isFlush())
            return -1;
        else if (!this.isFlush() && that.isFlush())
            return 1;
        else if (this.isFlush() && that.isFlush())
            return 0;
        else if (this.isStraight() != null || that.isStraight() != null) {
            if (this.isStraight() == null && that.isStraight() != null)
                return 1;
            else if (this.isStraight() != null && that.isStraight() == null)
                return -1;
            else if (this.isStraight() == that.isStraight())
                return 0;
            else if (this.isStraight().value > that.isStraight().value)
                return -1;
            else if (this.isStraight().value < that.isStraight().value)
                return 1;
        }
        else if (this.isThreeOfAKindValue() != null || that.isThreeOfAKindValue() != null) {
            if (this.isThreeOfAKindValue() == null && that.isThreeOfAKindValue() != null)
                return 1;
            else if (this.isThreeOfAKindValue() != null && that.isThreeOfAKindValue() == null)
                return -1;
            else if (this.isThreeOfAKindValue() == that.isThreeOfAKindValue())
                return 0;
            else if (this.isThreeOfAKindValue().value > that.isThreeOfAKindValue().value)
                return -1;
            else if (this.isThreeOfAKindValue().value < that.isThreeOfAKindValue().value)
                return 1;
        }
        else if (this.isTwoPair() != null || that.isTwoPair() != null) {
            if (this.isTwoPair() == null && that.isTwoPair() != null)
                return 1;
            else if (this.isTwoPair() != null && that.isTwoPair() == null)
                return -1;
            else if (this.isTwoPair() == that.isTwoPair())
                return 0;
            else if (this.isTwoPair().value > that.isTwoPair().value)
                return -1;
            else if (this.isTwoPair().value < that.isTwoPair().value)
                return 1;
        }
        else if (this.isPair() != null || that.isPair() != null) {
            if (this.isPair() == null && that.isPair() != null)
                return 1;
            else if (this.isPair() != null && that.isPair() == null)
                return -1;
            else if (this.isPair() == that.isPair())
                return 0;
            else if (this.isPair().value > that.isPair().value)
                return -1;
            else if (this.isPair().value < that.isPair().value)
                return 1;
        }
        else {
            if (this.isHighCard() == null && that.isHighCard() != null)
                return 1;
            else if (this.isHighCard() != null && that.isHighCard() == null)
                return -1;
            else if (this.isHighCard() == that.isHighCard())
                return 0;
            else if (this.isHighCard().value > that.isHighCard().value)
                return -1;
            else
                return 1;
        }
        return Integer.MAX_VALUE; // this means an error occurred
    }
}
