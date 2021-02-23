import com.sun.jdi.IntegerValue;

import java.util.*;

public class Application {
    public static void main(String[] args) {
        System.out.println(letterCasePermutation("a1b2"));
    }

    //01-14-2021 Warmups
    //Practice fizzBuzzBang (multiple of 7)
    public static void fizzBuzz()
    {
        for(int i = 1; i <= 100; i++)
        {
            if(i%3 == 0 && i%5 == 0)
            {
                System.out.println("fizzBuzz");
            }
            else if(i%3 == 0)
            {
                System.out.println("fizz");
            }
            else if (i%5 == 0)
            {
                System.out.println("buzz");
            }
            else
            {
                System.out.println(i);
            }
        }
    }

    public static int greatestOfThree(int a, int b, int c)
    {
        int maxNum = a;

        if(b > a) maxNum = b;
        if(c > maxNum) maxNum = c;

        return maxNum;
    }

    //TODO work on this
    //Doesn't handle duplicates
    public static int middleOfThree(int a, int b, int c)
    {
        int min = Integer.MIN_VALUE, max = Integer.MAX_VALUE, mid = Integer.MAX_VALUE;

        //Get max
        if(a > b && a > c)
        {
            max = a;
        }
        else if(b > a && b > c)
        {
            max = b;
        }
        else if(c > a && c > b)
        {
            max = c;
        }

        //Get min
        if(a < b && a < c)
        {
            min = a;
        }
        else if(b < a && b < c)
        {
            min = b;
        }
        else if(c < a && c < b)
        {
            min = c;
        }

        //Get mid
        if(a != min && a != max) mid = a;
        if(b != min && b != max) mid = b;
        if(c != min && c != max) mid = c;

        return mid;
    }

    //01-15-2021 Warmups
    //TODO work on some more
    public static boolean canBalance(int[] nums)
    {
        //return true if we can split array so that earlier numbers
        //equal later half
        int leftSum = 0, rightSum = 0, leftIndex = 0, rightIndex = 0;
        int totalSum = 0;

        for(int i = 0; i < nums.length; i++)
        {
            totalSum += nums[i];
        }

        if(totalSum%2 != 0)//If odd, false
        {
            return false;
        }

        for(int i = 0; i < nums.length; i++) {

            while(leftSum != (totalSum/2))
            {
                leftIndex = i;
                leftSum += nums[i];
            }
        }


        for(int i = 0; i < nums.length; i++) {

            while(rightSum != totalSum/2)//Right sum check
            {
                rightIndex = i;
                rightSum += nums[i];
            }
        }


        if(rightIndex == leftIndex+1 || leftIndex == rightIndex-1)
            return true;
        else
            return false;

    }

    public static boolean noTriples(int[] nums)
    {
        //Return true if no triples, false if there are triples
        int count = 0, previous = 0;
        boolean noTriple = false;
        for(int i = 0; i < nums.length; i++)
        {
            if(i == 0)
                previous = nums[0];
            previous = nums[i-1];


            if(nums[i] == previous)
                count++;
            else
                count = 0;

            if(count == 3)
                return false;
            else
                return true;
        }

        return true;
    }

    //01-19-2021 Warmups
    //Given two arrays of size 100 each representing a 100 digit number
    //(Each element of the input array will have a value between 0-9)
    //return the 101 element sum of these two numbers
    //(In the output array, the digits should be between 0-9)
    //The digit at 0 is the one's place, index 1 is the 10's place, etc.
    public static int[] addBigNum(int[] left, int[] right)
    {
        int[] totalSum = new int[left.length+1];//Accounts for different sized arrays

        //Iterate through the arrays
        boolean carryOne = false;
        int sum = Integer.MIN_VALUE;
        for(int i = 0; i < left.length; i++)
        {
            if(carryOne)
                sum = left[i] + right[i] + 1;//Get the sum of the index with carried one
            else
                sum = left[i] + right[i];//Get the sum of the index

            if(sum > 9)//If the sum is greater than 10, carry is true
            {
                carryOne = true;
                sum %= 10;
            }
            else
                carryOne = false;

            totalSum[i] = sum;
        }

        if(carryOne)
        {
            totalSum[totalSum.length-1] = 1;
        }

        return totalSum;
    }

    //Multiplication variant of the previous problem
    //I.E. long multiplication implementation
    public static int[] multiplyBigNum(int[] left, int[] right)
    {
        int[] totalProduct = new int[left.length + right.length];//Product length 
        int carryNum = 0;
        boolean carry = false;
        
        for(int i = 0; i < left.length; i++)//First loop to iterate through denominator
        {
            int temp = 0;
            for(int j = 0; j < right.length; i++)//Second loop to iterate through numerator
            {
                
            }

        }

        return totalProduct;
    }

    //01-20-2021
    //return the length of a mirror contiguous set of numbers within an array
    public static int maxMirror(int[] nums)
    {
        int maxLength = 0;

        for(int i = 0; i < nums.length - maxLength; i++)
        {
            for(int j = nums.length-1; j >= i; j--)
            {
                if(nums[i] == nums[j])
                {
                    int currentLength = 1;
                    for(int offset = 1; i + offset < nums.length && j - offset >= 0; offset++)
                    {
                        if( nums[i+offset] == nums[j-offset])
                            currentLength++;
                        else
                            break;
                    }
                    if(currentLength > maxLength)
                        maxLength = currentLength;
                }
            }
        }

        return maxLength;
    }

    //01-21-2021
    //Using a map, group strings on names by their starting letters.
    public static Map<String, List<String>> groupByFirstTwoLetters(String[] toGroup)
    {
        return groupByFirstNLetters(toGroup, 2);
    }

    public static Map<String, List<String>> groupByFirstNLetters(String[] toGroup, int numLetters)
    {
        Map<String, List<String>> newMap = new HashMap<>();

        for(int i = 0; i < toGroup.length; i++)
        {
            String key = toGroup[i].length() < numLetters+1 ? toGroup[i] : toGroup[i].substring(0,numLetters);
            if(!newMap.containsKey(key))
            {
                newMap.put(key, new ArrayList(Arrays.asList(toGroup[i])));
            }
            else
            {
                newMap.get(key).add(toGroup[i]);
            }
        }

        return newMap;
    }

    //01-22-2021
    //Collatz Sequence
    public static long longestCollatzSequence() {
        int maxLength = 0;
        long maxNum = 0;

        for (int i = 2; i <= 1000000; i++)
        {
            int curLength = 1;
            long num = i;
            while (num != 1)
            {
                if ((num % 2) == 0)
                    num /= 2;
                else if(num%2 == 1)
                    num = num * 3 + 1;
                curLength++;
            }

            if (curLength > maxLength)
            {
                maxLength = curLength;
                maxNum = i;
            }
        }

        return maxNum;
    }

    //01-25-2021
    //Flip an integer without using String or arrays
    public static int flipInt(int flip)
    {
        int flippedInt = 0;

        while (flip != 0) {
            flippedInt *= 10; // Add another ones place to flipInt
            flippedInt += flip % 10; // Add the next digit to flipInt

            flip /= 10; // Take away last digit from flip
        }

        return flippedInt;
    }

    //01-25-2021 Technical Interview Prep
    public static int lengthOfLongestSubstring(String s) {

        ArrayList<String> combinations = new ArrayList<>();

        for(int i = 0; i < s.length(); i++) {
            for(int j = 1; j <= s.length() - i; j++ ) {
                combinations.add(s.substring(i, i+j));
            }
        }

        String max = "";
        for(int i = 0; i < combinations.size(); i++) {
            if(combinations.get(i).length() > max.length() && !isDuplicate(combinations.get(i)))
                max = combinations.get(i);
        }

        return max.length();
    }

    public static boolean isDuplicate(String str) {
        for (int i = 0; i < str.length(); i++) {
            for (int j = i + 1; j < str.length(); j++) {
                if (str.charAt(i) == str.charAt(j)) {
                    return true;
                }
            }
        }
        return false;
    }

    //01-26-2021
    //A perfect number is one where the sum of all factors = 2x that number
    public static boolean isPerfect(int num) {
        int denom = num;
        int sum = 0;

        while(denom != 0) {
            if(num%denom == 0) {
                sum += denom;
                denom--;
            }
            else {
                denom--;
            }
        }
        return sum == (num*2);
    }

    //01-27-2021
//    public static boolean isValidSudoku(char[][]board) {
//        boolean valid = true;
//        List<Character> row = new ArrayList<>();
//        List<Character> column = new ArrayList<>();
//        List<Character> box = new ArrayList<>();
//
//        for(int i = 0; i < board.length; i++) {// iterate through the board
//            //Clear previous rows/columns
//            row.clear();
//            column.clear();
//            box.clear();
//
//            for(int j = 0; j < board[i].length; j++) {
//
//                if(board[i][j] != '.') {
//                    row.add(board[i][j]);//Fill temp list
//                }
//
//                if(board[j][i] != '.') {
//                    column.add(board[j][i]);//Fill column list
//                }
//
//            }
//
//            //Get 3x3 grid numbers
//            //TODO Fix this loop
//            for(int j = 0; j < 3; j++) {
//                for(int k = 0; k < 3; k++) {
//                    if(board[j][k] != '.') {
//                        box.add(board[j][k]);
//                    }
//                }
//            }
//
//
//            //Check current columns/rows for duplicates
//            valid = checkList(row) && checkList(column) && checkList(box);
//
//        }
//
//        return valid;
//
//    }

    public static boolean checkList(List<Character> list) {
        boolean valid = true;

        for(int k = 0; k < list.size(); k++) {//Check the rows and columns
            for(int l = k + 1; l < list.size(); l++) {
                if(list.get(k) == list.get(l)) {
                    valid = false;
                }
            }
        }

        return valid;
    }

    //Temp sudoku solution for 01-28-2021 problem
    public static boolean isValidSudoku(char[][] board) {
        Set<String> set = new HashSet<>();
        for(int row = 0; row < board.length; row++) {
            for(int col = 0; col < board[0].length; col++) {
                char val = board[row][col];
                if(val != '.') {
                    int box = (row / 3 * 3) + (col / 3);
                    if(!set.add("r" + row + val)
                    || !set.add("c" + col + val)
                    || !set.add("b" + box + val))
                        return false;
                }
            }
        }
        return true;
    }

    public void solveSudoku(char[][] board) {
        solve(board);
    }

    public boolean solve(char[][] board) {
        for(int row = 0; row < board.length; row++) {//Iterate through board
            for(int col = 0; col < board[0].length; col++) {
                //If board spot is empty, try and fill in values 1-9
                //else, if full, move on to next spot
                if(board[row][col] == '.') {
                    for(int valueToFill = 1; valueToFill <= 9; valueToFill++) {
                        char charValueToFill = (char)(valueToFill+48);
                        board[row][col] = charValueToFill;
                        //Once the value is filled, check to see if it is valid && recursively call solve
                        //If it is not valid, replace with the empty character and try again
                        if(isValidSudoku(board) && solve(board)) {
                            return true;
                        }
                       //Set back to empty character
                        board[row][col] = '.';

                    }
                    //If the program reaches this point, it tried all possible numbers and a solution
                    //isn't possible, return false
                    return false;
                }
            }
        }
        //If the program reaches this point, the whole board is filled
        return true;
    }

    //Technical Interview Prep for 02-08-2021
    public static int minDays(int n) {
        int numDays = 0;

        if(n == 1) {
            return 1;
        }

        int p1 = 0, p2 = 0, p3 = 0;
        if(n % 2 == 0) {
            p1 = minDays(n / 2) + 1;
        }
        if(n % 3 == 0) {
            p2 = minDays( (n/3)) + 1;
        }

        p3 = minDays(n-1) + 1;

        if(p1 < p2 && p1 < p3) {
            numDays = p1;
        }
        else if(p2 < p1 && p2 < p3) {
            numDays = p2;
        }
        else if(p3 < p2 && p3 < p3) {
            numDays = p3;
        }

        return numDays;
    }

    //Warmup for 02-09-2021
    public static boolean validTicTacToe(String[] board) {

        int xCount = 0, oCount = 0;
        for(String toCheck : board) {
            for(int i = 0; i < 3; i++) {
                if(toCheck.charAt(i) == 'X')
                    xCount++;
                else if (toCheck.charAt(i) == 'O')
                    oCount++;
            }
        }


        if(oCount > xCount) //X moves first case
            return false;

        if(xCount > oCount+1)//Players take turns case
            return false;

        if(playerWins(board, 'X') && playerWins(board, 'O'))//Both win
            return false;

        if(playerWins(board, 'O') && xCount > oCount)//X moved after O won
            return false;

        if(playerWins(board, 'X') && xCount == oCount)//O moved after X won
            return false;

        return true;
    }

    public static boolean playerWins(String[] board, char player) {
        if(checkRows(board, player) || checkCols(board, player) || checkDiags(board, player)) {
            return true;
        }

        return false;
    }

    public static boolean checkRows(String[] board, char player) {
        for(int i = 0; i < 3; i++) {
            if(board[i].charAt(0) == player && board[i].charAt(1) == player && board[i].charAt(2) == player) {
                return true;
            }
        }

        return false;
    }

    public static boolean checkCols(String[] board, char player) {
        for(int i = 0; i < 3; i++) {
            if((board[0].charAt(i) == player && board[1].charAt(i) == player && board[2].charAt(i) == player)
            ) {
                return true;
            }
        }
        return false;
    }

    public static boolean checkDiags(String[] board, char player) {
        for(int i = 0; i < 3; i++) {
            if((board[0].charAt(0) == player && board[1].charAt(1) == player && board[2].charAt(2) == player)
                    || (board[0].charAt(2) == player && board[1].charAt(1) == player && board[2].charAt(0) == player)) {
                return true;
            }
        }
        return false;
    }

    //Technical Interview Prep 02-15-2021
    public static int calculate(String expression) {
        int toReturn = 0;

        String trimmedString = expression.replace(" ", "");
        String[] numbers = trimmedString.split("[+\\-\\*\\/]");
        String operand = trimmedString.substring(numbers[0].length(), numbers[0].length()+1);
        Integer num1 = Integer.valueOf(numbers[0]);
        Integer num2 = Integer.valueOf(numbers[1]);

        switch(operand) {
            case "+":
                toReturn = num1 + num2;
                break;
            case "-":
                toReturn = num1 - num2;
                break;
            case "*":
                toReturn = num1 * num2;
                break;
            case "/":
                toReturn = num1 / num2;
                break;
        }


        return toReturn;
    }

    //Warmup for 02-16-2021
    public static List<String> letterCasePermutation(String S) {
        List<String> toReturn = new ArrayList<>();

        char[] charArr = S.toCharArray();

        permutationHelper(toReturn, charArr, 0);

        return toReturn;
    }


    public static void permutationHelper(List<String> toReturn, char[] charArr, int start) {
        String stringToAdd = String.valueOf(charArr);

        toReturn.add(stringToAdd);//Add string to results list

        for(int i = start; i < stringToAdd.length(); i++) {//Go through whole string
            char c = charArr[i];

            if(Character.isLetter(charArr[i])) {//check if it is letter or not

                if(Character.isUpperCase(charArr[i])) //if uppercase, make lower case
                    charArr[i] = Character.toLowerCase(charArr[i]);
                else if (Character.isLowerCase(charArr[i]))//else lowercase, make uppercase
                    charArr[i] = Character.toUpperCase(charArr[i]);

                permutationHelper(toReturn, charArr, i+1);//make recursive call on next index

                charArr[i] = c;
            }
        }

    }

}
