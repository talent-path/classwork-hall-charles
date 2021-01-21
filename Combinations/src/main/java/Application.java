import java.util.ArrayList;
import java.util.List;

public class Application {
    public static void main(String[] args) {
        String[] possibleInputs = {"a", "b", "c", "d", "e", "f", "g"};

        List<String> selected = new ArrayList<>();

        List<List<String>> allCombinations = new ArrayList<>();

        sevenChooseFive(possibleInputs, 0, selected, allCombinations);

        for(List<String> combination: allCombinations)
        {
            for(String notCard : combination)
            {
                System.out.print(notCard);
            }
            System.out.println();
        }

    }

    //Will return a list of hands objects in our implementation
    public static void sevenChooseFive(
            String[] possible,
            int nextIndex,
            List<String> currentlySelected,
            List<List<String>> allCombinations)
    {
        //iterates through each card
        //for each card, we either include it or don't
        //we'll try the recursion with the card included
        //and with the card excluded

        //Number of cards we have currently chosen
        int chosenNum = currentlySelected.size();
        //Number of cards we need to complete the hand
        int remainingNum = 5 - chosenNum;
        //Number of cards left to be checked
        int availableCards = possible.length - nextIndex;

        if(currentlySelected.size() == 5)
        {
            List<String> copy = new ArrayList<>();
            for(String toCopy : currentlySelected) copy.add(toCopy);
            allCombinations.add(copy);
            return;
        }

        if(availableCards < remainingNum) return;

        sevenChooseFive(possible, nextIndex + 1, currentlySelected, allCombinations);

        //try with the "card" first
        currentlySelected.add(possible[nextIndex]);
        sevenChooseFive(possible, nextIndex + 1, currentlySelected, allCombinations);

        currentlySelected.remove(currentlySelected.size() - 1);

        //try without choosing the card
        sevenChooseFive(possible, nextIndex + 1, currentlySelected, allCombinations);

    }
}
