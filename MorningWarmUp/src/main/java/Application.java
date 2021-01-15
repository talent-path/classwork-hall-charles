public class Application {
    public static void main(String[] args) {
        System.out.println(noTriples(new int[] {1,2,3}));
        System.out.println(noTriples(new int[] {1,1,1}));
    }

    //01-14-2021 Warmups
    //TODO work on this
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

    //TODO work on this too
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

}
