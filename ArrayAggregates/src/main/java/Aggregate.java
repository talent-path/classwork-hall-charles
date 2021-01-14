public class Aggregate {

    //Find min number and return it
    public static int min(int[] arr)
    {
        int min = Integer.MAX_VALUE;
        //iterate through entire array
        for(int i = 0; i < arr.length; i++)
        {
            //If the value at current position is less than min
            if(arr[i] < min)
            {
                //Set new min
                min = arr[i];
            }
        }
        //Return min
        return min;
    }

    //Find max number and return it
    public static int max(int[] arr)
    {
        int max = Integer.MIN_VALUE;
        //iterate through entire array
        for(int i = 0; i < arr.length; i++)
        {
            //If the value at current position is greater than max
            if(arr[i] > max)
            {
                //Set new max
                max = arr[i];
            }
        }
        //Return max
        return max;
    }

    //Find sum and return it
    public static int sum(int[] arr)
    {
        int sum = 0;
        //iterate through entire array
        for(int i = 0; i < arr.length; i++)
        {
            //Add value at current position to sum
            sum += arr[i];
        }
        //Return sum
        return sum;
    }

    //Find average and return it
    public static double average(int[] arr)
    {
        //Get sum of array and divide by total num of elements
        double len = arr.length;
        double avg =  sum(arr) / len;

        //Return avg
        return avg;
    }

    //Find std deviation of all numbers in the array and return it
    public static double standardDeviation(int[] arr)
    {
        //First compute the average
        double avg = average(arr);

        //Then add the SQUARE of the DIFFERENCE between the average and each number
        double sumDiff = 0.0;
        for(int i = 0; i < arr.length; i++)
        {
            double temp = Math.pow((arr[i] - avg),2);
            sumDiff += temp;
        }

        //Find the variance
        double len = arr.length;
        double variance = sumDiff / (len-1);

        //Take the square root of the variance
        return Math.sqrt(variance);
    }

}
