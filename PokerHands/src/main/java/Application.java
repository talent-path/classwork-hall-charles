import jdk.swing.interop.SwingInterOpUtils;

import java.io.File;
import java.util.*;

/**
 * Application class that will first fire up our implementation of PokerHands
 */
public class Application {
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
     * The psvm will be the function that will give us the set of
     * arguments to run the app
     * @param args
     * @throws Exception will be thrown if the file does not exist
     */
    public static void main(String[] args) throws Exception {

        // poker.txt file is what we will be using to test our code
        File file =
                new File("/Users/charleshall/classwork-hall-charles/PokerHands/src/main/poker.txt");
        Scanner sc = new Scanner(file);
        // initialized player1WinCount so we check
        // if we have the correct amount of total p1 wins
        int player1WinCount = 0;

        // until there is no more next line it will run the while loop
//        while (sc.hasNextLine()) {
//            String currLine = sc.nextLine();
//            String[] str = currLine.split(" ");
//            int[] bothHands = new int[str.length];
//            for (int i = 0; i < str.length; i++) {
//                int v = faceValue.get(str[i].charAt(0));
//                int s = suit.get(str[i].charAt(1));
//                bothHands[i] = v * 4 + s;
//            }
//            Card[] hand1Cards = new Card[5];
//            Card[] hand2Cards = new Card[5];
//            for( int i = 0; i < bothHands.length; i++ ){
//                if( i < 5 ){
//                    hand1Cards[i] = new Card(bothHands[i]);
//                } else {
//                    hand2Cards[i-5] = new Card(bothHands[i]);
//                }
//            }
//
//            PokerHand hand1 = new PokerHand(hand1Cards);
//            PokerHand hand2 = new PokerHand(hand2Cards);
//
//
//            int hand1WinsResult = hand1.compareTo(hand2);
//            if( hand1WinsResult == -1 ) player1WinCount++;
//        }

        //Code for the combinations assignment
        int[] arr = {48, 49, 50, 51, 44, 45, 46};
        Card[] card = new Card[arr.length];
        Combinations comb = new Combinations();
        List<Card> selected = new ArrayList<>();
        List<PokerHand> allCombinations  = new ArrayList<>();

        comb.getCombinations( card, 0, 3, selected, allCombinations );

        Collections.sort(allCombinations, new Comparator<PokerHand>() {
            @Override
            public int compare(PokerHand o1, PokerHand o2) {
                return o1.compareTo(o2);
            }
        });

        System.out.println();

        for( PokerHand combination : allCombinations ) {
            for( Card notCard : combination.getCards() ) {
                System.out.print(notCard.getCardValue() + " ");
                System.out.println( notCard.getCardSuit() );
            }
            System.out.println();
        }

        System.out.println("Player 1 has won " + player1WinCount + " games.");

    }

    //player one's cards are 0-4
    //player two's cards are 5-9
    public static boolean playerOneWins( int[] bothHands ){
        throw new UnsupportedOperationException();
    }

    //generates an array of size 10 representing 2 hands of poker
    //the values are 0-51
    //the suit is value%4            (0-spades, 1-diamonds, 2-clubs, 3-hearts)
    //the card is value/4 + 2       J = 11, Q = 12, K = 13, A = 14
    public static int[] generatePokerHands(){
        int [] cards = new int[10];
        for( int i = 0; i < 10; i++ ){
            int card = Integer.MIN_VALUE;

            while( card == Integer.MIN_VALUE ){
                card = Rng.nextInt(0,51);
                for( int j = 0; j < i; j++ ){
                    if( cards[j] == card ) card = Integer.MIN_VALUE;
                }

            }
            cards[i] = card;
        }

        Arrays.sort(cards, 0, 4);
        Arrays.sort(cards, 5, 9);

        return cards;
    }

}
