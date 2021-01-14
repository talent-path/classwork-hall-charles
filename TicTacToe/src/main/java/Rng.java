import java.util.Random;

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

}