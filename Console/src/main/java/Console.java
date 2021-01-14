import java.util.Scanner;

public class Console {

    public static int readInt(String msg, int min, int max)
    {
        boolean valid = false;
        int parsedInput = Integer.MIN_VALUE;

        while(!valid)
        {
            parsedInput = readInt(msg);
            valid = parsedInput >= min && parsedInput <= max;
        }

        return parsedInput;
    }

    public static int readInt(String msg)
    {
        Scanner scan = new Scanner(System.in);

        boolean valid = false;
        int parsedInput = Integer.MIN_VALUE;

        while(!valid)
        {
            print(msg);
            String input = scan.nextLine();
            try
            {
                parsedInput = Integer.parseInt(input);
                valid = true;
            }
            catch(NumberFormatException e)
            {
            }
        }

        return parsedInput;
    }

    public static double readDouble(String msg, double min, double max)
    {
        boolean valid = false;
        double parsedInput = Double.NaN;

        while(!valid)
        {
            parsedInput = readInt(msg);
            valid = parsedInput >= min && parsedInput <= max;
        }

        return parsedInput;
    }

    public static double readDouble(String msg)
    {
        Scanner scan = new Scanner(System.in);

        boolean valid = false;
        double parsedInput = Double.NaN;

        while(!valid)
        {
            print(msg);
            String input = scan.nextLine();
            try
            {
                parsedInput = Double.parseDouble(input);
                valid = true;
            }
            catch(NumberFormatException e)
            {
            }
        }

        return parsedInput;
    }

    public static void print(String printMsg)
    {
        System.out.println(printMsg);
    }
}
