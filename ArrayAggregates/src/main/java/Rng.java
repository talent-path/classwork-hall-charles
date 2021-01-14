import java.util.Random;

//Singleton pattern
//Single static instance of something inside of a class
//which we then use throughout
//Min and max would be 1 and 3
public class Rng {

    static Random rng = new Random();

    public static int randInt(int incMin, int incMax)
    {
        //This calls takes an exclusive upper bound (max)
        //returns a number between 0 and that bound - 1
        //rng.nextInt();

        int rand = incMin + rng.nextInt((incMax - incMin) + 1);

        return rand;
    }

    public static double randDouble(double min, double max)
    {
        double rand = min + rng.nextDouble() * (max - min); //range is min - max

        return rand;
    }

    public static boolean coinFlip()
    {
        return rng.nextBoolean();
    }

}
