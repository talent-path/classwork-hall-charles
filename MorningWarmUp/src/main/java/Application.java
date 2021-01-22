import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.ArrayList;
import java.util.HashMap;

public class Application {
    public static void main(String[] args) {

        System.out.println(longestCollatzSequence());

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

}
