public class Application {
    public static void main(String[] args) {

//        System.out.println(middleOfThree(1,2,3));
//        System.out.println(middleOfThree(1,3,2));
//        System.out.println(middleOfThree(2,1,3));
//        System.out.println(middleOfThree(2,3,1));
//        System.out.println(middleOfThree(3,1,2));
//        System.out.println(middleOfThree(3,2,1));
//
//        System.out.println(greatestOfThree(1,2,3));
        fizzBuzz();
    }

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



}
