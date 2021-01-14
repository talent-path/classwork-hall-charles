import java.util.Scanner;

public class Console {

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


    public static void print(String printMsg)
    {
        System.out.println(printMsg);
    }
}
