import java.util.Arrays;

//Board is a char array of X's and O's or empty space character
public class App {

    public static void main(String[] args) {
        //char[] test = {'O','O','O','O','M','S','P','Z','X'};
        //System.out.println(getRoundOutcome(test));
        play();
    }

    public static int getGameMode()
    {
        return Console.readInt("Enter your game mode: 1(PvC) 2(PvP) 3 (CvP)");
    }

    //Initializes an empty board state
    //return: a 1-d char array of empty space characters.
    public static void initBoard(char[] board)
    {
        Arrays.fill(board, 'E');
    }

    //Gets the number of rounds for the game.
    //return: a user inputted integer value
    public static int getRounds()
    {
        return Console.readInt("Enter the number of rounds you would like to play. (At least 1)");
    }

    //TODO Think about a memory save feature
    // to remember already taken positions
    //Gets the computer's input
    //return: and integer value between 0 and 8
    public static int getComputerInput(char[] board)
    {
        int position = Rng.randInt(0,8);

        //If the position generated is invalid, make a new one
        while(!isValid(board, position))
            position = Rng.randInt(0,8);

        return position;
    }

    //Gets the user input
    //return: an integer between 0 and 8
    public static int getUserInput()
    {
        return Console.readInt("Enter the position you want to take. (0-8)");
    }

    //Prints the current state of the board
    public static void printBoard(char[] board)
    {
        System.out.println("|" + board[0] + "|" + board[1] + "|" + board[2] + "|");
        System.out.println("|" + board[3] + "|" + board[4] + "|" + board[5] + "|");
        System.out.println("|" + board[6] + "|" + board[7] + "|" + board[8] + "|");
    }

    //Fills the position of the board and returns the outcome
    public static int fillPosition(char[] board, int position, int user)
    {
        if(isValid(board, position))
        {
            if(user == 1)
            {
                board[position] = 'X';
            }
            else
                board[position] = 'O';
        }

        return getRoundOutcome(board);

    }

    //Checks if the input from user/computer is a valid position
    //return: boolean true or false
    public static boolean isValid(char[] board, int position)
    {
        return board[position] == 'E';
    }

    //Checks if the current board state is full
    //return: boolean true or false
    public static boolean isFull(char[] board)
    {
        boolean full = false;
        for(int i = 0; i < board.length; i++)
        {
            if(board[i] == 'E')
                return false;
            else
                full = true;
        }

        return full;
    }

    //Checks the outcome of a game once the board and increment counters
    //return: an integer value between 1-3 corresponding to game outcome (1:win 2:loss 3:draw)
    public static int getRoundOutcome(char[] board) {

        //Win conditions for user
        if ((board[0] == 'X' && board[1] == 'X' && board[2] == 'X')//Horizontal wins
                || (board[3] == 'X' && board[4] == 'X' && board[5] == 'X')
                || (board[6] == 'X' && board[7] == 'X' && board[8] == 'X'))
            return 1;
        else if ((board[0] == 'X' && board[3] == 'X' && board[6] == 'X')//Vertical wins
                || (board[1] == 'X' && board[4] == 'X' && board[7] == 'X')
                || (board[2] == 'X' && board[5] == 'X' && board[8] == 'X'))
            return 1;
        else if ((board[0] == 'X' && board[4] == 'X' && board[8] == 'X')//Diagonal wins
                || (board[2] == 'X' && board[4] == 'X' && board[6] == 'X'))
            return 1;//Else, check computer wins
        else if ((board[0] == 'O' && board[1] == 'O' && board[2] == 'O')//Horizontal wins
                || (board[3] == 'O' && board[4] == 'O' && board[5] == 'O')
                || (board[6] == 'O' && board[7] == 'O' && board[8] == 'O'))
            return 2;
        else if ((board[0] == 'O' && board[3] == 'O' && board[6] == 'O')//Vertical wins
                || (board[1] == 'O' && board[4] == 'O' && board[7] == 'O')
                || (board[2] == 'O' && board[5] == 'O' && board[8] == 'O'))
            return 2;
        else if ((board[0] == 'O' && board[4] == 'O' && board[8] == 'O')//Diagonal wins
                || (board[2] == 'O' && board[4] == 'O' && board[6] == 'O'))
            return 2;
        else if(isFull(board))
            //Else, if board is full and none of those conditions are met
            return 3;
        else return 3;
    }

    //Prints the results of the game
    public static void printResults(int wins, int losses, int draws)
    {
        System.out.println("Final Results: ");
        System.out.println("-----------------------");
        System.out.println("Wins: " + wins);
        System.out.println("Losses: " + losses);
        System.out.println("Draws: " + draws);
    }

    //Game logic method
    public static void play()
    {
        // Win/Loss/Draw counters
        int wins = 0, losses = 0, draws = 0;

        //Get game mode
        int gameMode = getGameMode();
        
        //Get the number of rounds for the game
        int rounds = getRounds();
        while(rounds < 1)
        {
            rounds = getRounds();
        }
        //Play for number of rounds in the game
        for(int i = rounds; i > 0; i--) {
            System.out.println("Good luck!!");
            int outcome = 0;
            char[] board = new char[9];

            //Init and print empty board
            initBoard(board);

            //While the game is still in play
            if(gameMode == 1)
            {//PvC game mode
                printBoard(board);
                while (!isFull(board)) {
                    //Get user and comp position
                    int userPosition = getUserInput();
                    int compPosition = getComputerInput(board);

                    //Check if the user position is valid, otherwise reprompt for new position
                    while (!isValid(board, userPosition))
                        userPosition = getUserInput();

                    //Update the outcome of filling the board and check if win con is met
                    outcome = fillPosition(board, userPosition, 1);
                    if (outcome == 1 || outcome == 2) {
                        printBoard(board);
                        break;
                    }

                    //Check if the position is valid, otherwise get new position
                    while (!isValid(board, compPosition))
                        compPosition = getComputerInput(board);

                    //Update the outcome of filling the board and check if win con is met
                    outcome = fillPosition(board, compPosition, 0);
                    if (outcome == 1 || outcome == 2) {
                        printBoard(board);
                        break;
                    }

                    //Print the board state
                    printBoard(board);
                }//while loop
            }
            else if(gameMode == 2)
            {//PvP game mode
                printBoard(board);
                while (!isFull(board)) {
                    //Get user and comp position
                    int userPosition = getUserInput();
                    int user2Position = getUserInput();

                    //Check if the user position is valid, otherwise reprompt for new position
                    while (!isValid(board, userPosition))
                        userPosition = getUserInput();

                    //Update the outcome of filling the board and check if win con is met
                    outcome = fillPosition(board, userPosition, 1);
                    if (outcome == 1 || outcome == 2) {
                        printBoard(board);
                        break;
                    }

                    //Check if the position is valid, otherwise get new position
                    while (!isValid(board, user2Position))
                        user2Position = getUserInput();

                    //Update the outcome of filling the board and check if win con is met
                    outcome = fillPosition(board, user2Position, 0);
                    if (outcome == 1 || outcome == 2) {
                        printBoard(board);
                        break;
                    }

                    //Print the board state
                    printBoard(board);
                }//while loop
            }
            else if(gameMode == 3)
            {//CvP game mode
                while (!isFull(board)) {
                    //Get comp and user position
                    int compPosition = getComputerInput(board);

                    //Check if the comp position is valid, otherwise reprompt for new position
                    while (!isValid(board, compPosition))
                        compPosition = getComputerInput(board);

                    //Update the outcome of filling the board and check if win con is met
                    outcome = fillPosition(board, compPosition, 0);
                    if (outcome == 1 || outcome == 2) {
                        printBoard(board);
                        break;
                    }

                    printBoard(board);//Show computer move
                    int userPosition = getUserInput();//Get user position

                    //Check if the user position is valid, otherwise get new position
                    while (!isValid(board, userPosition))
                        userPosition = getUserInput();

                    //Update the outcome of filling the board and check if win con is met
                    outcome = fillPosition(board, userPosition, 1);
                    if (outcome == 1 || outcome == 2) {
                        printBoard(board);
                        break;
                    }

                    //Print the board state
                }//while loop
            }

            if(outcome == 3 || isFull(board))
            {
                System.out.println("Tough game, it's a draw!\n");
                draws++;
            }
            else if (outcome == 1)
            {
                System.out.println("Congratulations you won this round!\n");
                wins++;
            }
            else if (outcome == 2)
            {
                System.out.println("Uh oh, you lost this round!\n");
                losses++;
            }

        }//for loop

        printResults(wins,losses,draws);

    }
}
