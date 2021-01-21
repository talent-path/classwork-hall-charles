import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Combinations {

    Card[] posInput;
    PokerHand hand;
    List<Card> currSelected;
    List<PokerHand> allComb;

//    public Combinations(Card[] posInput, PokerHand hand) {
//        this.posInput = posInput;
//        this.hand = hand;
//        currSelected = new ArrayList<>();
//        allComb = new ArrayList<>();
//    }


    public static void getCombinations(Card[] possible, int nextIndex, int choose, List<Card> currSelected, List<PokerHand> allComb) {
        int chosenNum = currSelected.size();
        int remainingNum = choose - chosenNum;
        int availableCards = possible.length - nextIndex;

        //base cases
        if( currSelected.size() == choose ){
            List<Card> copy = new ArrayList<>();
            for( Card toCopy : currSelected ) copy.add( toCopy );

            Card[] cardArr = new Card[copy.size()];
            for(int i = 0; i < copy.size(); i++) {
                cardArr[i] = copy.get(i);
            }

            allComb.add( new PokerHand(cardArr) );
            return;
        }

        if( availableCards < remainingNum )
            return;

        //try with the "card" first
        currSelected.add( possible[nextIndex] );
        getCombinations( possible, nextIndex +1, choose, currSelected, allComb);

        currSelected.remove( currSelected.size() - 1 );

        //try without choosing the card
        getCombinations( possible, nextIndex + 1, choose, currSelected, allComb);
    }

}
