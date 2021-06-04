using System;
using System.Collections.Generic;
using RPG.Classes.Armor;
using RPG.Classes.Fighter;
using RPG.Classes.Weapon;

namespace RPG
{
    class Program
    {
        static Random rand = new Random();
        static List<Fighter> enemyList = new List<Fighter>();

        static void Main(string[] args)
        {
            Fighter player = SetUpPlayer();
            int roomNum = 1;
            bool playerDefeated = false;

            int[,] room = new int[15,15];

            //While the player has not been defeated or beaten the last room
            while (playerDefeated == false || roomNum != 15)
            {
                //Create the room
                InitRoom(room, roomNum);
                bool roomComplete = false;
                //While room is not completed
                while (!roomComplete)
                {
                    //Prompt user for movement
                    PrintBoard(room, roomNum);
                    Console.WriteLine("Enter where you would like to go");
                    char input = char.Parse(Console.ReadLine());

                    //Move the user
                    Move(input, player, room);

                    //Check if the player has reached the exit
                    if (player.RowPosition == 14 && player.ColPosition == 14)
                    {
                        Console.WriteLine("Congrats! You got past room " + roomNum);
                        player.RowPosition = 0;
                        player.ColPosition = 0;
                        roomComplete = true;
                        roomNum++;
                        break;
                    }

                    //Move enemies
                    EnemyMove(player, room);

                    if(player.Health <= 0)
                    {
                        break;
                    }
                }
                //Added because for some reason despite player defeated == true, does not break while loop??
                if(player.Health <= 0)
                {
                    break;
                }
            }

            if(player.Health <= 0)
            {
                Console.WriteLine("You have been defeated!");
            }
            else
            {
                Console.WriteLine("You have won!");
            }
            

        }

        //Add list of enemies
        private static void InitRoom(int[,] room, int roomNum)
        {
            enemyList.Clear();
            //0 for empty
            //1 for enemy
            //2 for player
            for (int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    //Place the player
                    if(i == 0 && j == 0)
                    {
                        room[i,j] = 2;
                    }
                    else//Empty spot
                    {
                        room[i,j] = 0;
                    }
                }
            }

            //Placing enemies
            for (int i = 0; i < roomNum + 1; i++)
            {
                bool placed = false;

                //While an enemy has not been placed, attempt to place
                while (!placed)
                {
                    int spawnRow = rand.Next(0, 14);
                    int spawnCol = rand.Next(0, 14);

                    Fighter enemy = SetUpEnemy();
                    enemyList.Add(enemy);

                    //If the spot is not empty, place
                    if (room[spawnRow, spawnCol] == 0)
                    {
                        room[spawnRow, spawnCol] = 1;
                        enemy.ColPosition = spawnCol;
                        enemy.RowPosition = spawnRow;
                        placed = true;
                    }
                }
            }

        }

        private static bool Move(char direction, Fighter fighter, int[,] room)
        {

            bool valid = true;
            bool enemyDefeated = false;

            //If the position is not empty (enemy is there)
            if((fighter.RowPosition != 0 && direction == 'w' && room[fighter.RowPosition - 1, fighter.ColPosition] != 0)
                || (fighter.RowPosition != 14 && direction == 's' && room[fighter.RowPosition + 1, fighter.ColPosition] != 0)
                || (fighter.ColPosition != 0 && direction == 'a' && room[fighter.RowPosition, fighter.ColPosition - 1] != 0)
                || (fighter.ColPosition != 14 && direction == 'd' && room[fighter.RowPosition, fighter.ColPosition + 1] != 0))
            {
                //Battle
                enemyDefeated = Battle(fighter, direction, room);
                //If the enemy is defeated, you can move there bc it is empty, otherwise no bc the enemy is still there
                valid = enemyDefeated;
            }

            if (fighter.Health <= 0)
            {
                return true;
            }

            //Row 0 can't move up and row 14 can't move down
            if((fighter.RowPosition == 0 && direction == 'w') || (fighter.RowPosition == 14 && direction == 's'))
            {
                valid = false;
            }

            //Col 0 can't move left and col 14 can't move right
            if((fighter.ColPosition == 0 && direction == 'a') || (fighter.ColPosition == 14 && direction == 'd'))
            {
                valid = false;
            }

            //If valid move, perform move
            if(valid)
            {
                switch(direction)
                {
                    case 'w'://Move up one position
                        room[fighter.RowPosition - 1, fighter.ColPosition] = 2;
                        room[fighter.RowPosition, fighter.ColPosition] = 0;
                        fighter.RowPosition -= 1;
                        break;
                    case 'a'://Move left one position
                        room[fighter.RowPosition, fighter.ColPosition - 1] = 2;
                        room[fighter.RowPosition, fighter.ColPosition] = 0;
                        fighter.ColPosition -= 1;
                        break;
                    case 's'://Move down one position
                        room[fighter.RowPosition + 1, fighter.ColPosition] = 2;
                        room[fighter.RowPosition, fighter.ColPosition] = 0;
                        fighter.RowPosition += 1;
                        break;
                    case 'd'://Move right one position
                        room[fighter.RowPosition, fighter.ColPosition + 1] = 2;
                        room[fighter.RowPosition, fighter.ColPosition] = 0;
                        fighter.ColPosition += 1;
                        break;
                }
            }

            return fighter.Health >= 0;
        }

        private static bool Battle(Fighter player, char direction, int[,] room)
        {
            int enemyCol = 0, enemyRow = 0;

            switch(direction)
            {
                case 'w':
                    enemyCol = player.ColPosition;
                    enemyRow = player.RowPosition - 1;
                    break;
                case 'a':
                    enemyCol = player.ColPosition - 1;
                    enemyRow = player.RowPosition;
                    break;
                case 's':
                    enemyCol = player.ColPosition;
                    enemyRow = player.RowPosition + 1;
                    break;
                case 'd':
                    enemyCol = player.ColPosition + 1;
                    enemyRow = player.RowPosition;
                    break;
            }

            Fighter enemy = GetEnemy(enemyRow, enemyCol);

            Console.WriteLine(player.Name + " attacks " + enemy.Name + " with a " + player.Weapon.Name + "!");

            player.Attack(enemy);

            Console.WriteLine("Current Health: " + player.Health);
            Console.WriteLine("Enemy Health: " + enemy.Health);

            if (enemy.Health <= 0)
            {
                room[enemy.RowPosition, enemy.ColPosition] = 0;
                Console.WriteLine("You have defeated the " + enemy.Name);
                Console.WriteLine("---------------------");
            }

            return enemy.Health <= 0;
        }

        private static bool EnemyMove(Fighter player, int[,] room)
        {
            bool playerDefeated = false;
            foreach (Fighter enemy in enemyList)
            {
                if (enemy.Health > 0)
                {
                    int colDiff = enemy.ColPosition - player.ColPosition;
                    int rowDiff = enemy.RowPosition - player.RowPosition;

                    //If player is adjacent to enemy

                    if ((enemy.ColPosition != 14 && room[enemy.RowPosition, enemy.ColPosition + 1] == 2)
                        || (enemy.ColPosition != 0 && room[enemy.RowPosition, enemy.ColPosition - 1] == 2)
                        || (enemy.RowPosition != 14 && room[enemy.RowPosition + 1, enemy.ColPosition] == 2)
                        || (enemy.RowPosition != 0 && room[enemy.RowPosition - 1, enemy.ColPosition] == 2))
                    {
                        playerDefeated = EnemyBattle(enemy, player, room);
                    }

                    //If the column difference is greater than row, move left/right
                    if (Math.Abs(colDiff) > Math.Abs(rowDiff))
                    {
                        //Negative difference, means player is to the right
                        if (colDiff <= 0)
                        {
                            if (enemy.Health > 0 && room[enemy.RowPosition, enemy.ColPosition + 1] == 0)
                            {
                                room[enemy.RowPosition, enemy.ColPosition + 1] = 1;
                                room[enemy.RowPosition, enemy.ColPosition] = 0;
                                enemy.ColPosition += 1;
                            }
                        }
                        else if (colDiff > 0)//Positive difference, means player is to the left
                        {
                            if (enemy.Health > 0 && room[enemy.RowPosition, enemy.ColPosition - 1] == 0)
                            {
                                room[enemy.RowPosition, enemy.ColPosition - 1] = 1;
                                room[enemy.RowPosition, enemy.ColPosition] = 0;
                                enemy.ColPosition -= 1;
                            }
                        }
                    }//Else if the row difference is greater than column, move up/down
                    else if (Math.Abs(rowDiff) > Math.Abs(colDiff))
                    {
                        //Negative difference, means player is down
                        if (rowDiff <= 0)
                        {
                            if (enemy.Health > 0 && room[enemy.RowPosition + 1, enemy.ColPosition] == 0)
                            {
                                room[enemy.RowPosition + 1, enemy.ColPosition] = 1;
                                room[enemy.RowPosition, enemy.ColPosition] = 0;
                                enemy.RowPosition += 1;
                            }
                        }
                        else if (rowDiff > 0)//Positive difference, means player is up
                        {
                            if (enemy.Health > 0 && room[enemy.RowPosition - 1, enemy.ColPosition] == 0)
                            {
                                room[enemy.RowPosition - 1, enemy.ColPosition] = 1;
                                room[enemy.RowPosition, enemy.ColPosition] = 0;
                                enemy.RowPosition -= 1;
                            }
                        }
                    }
                }
            }

            return playerDefeated;
        }

        private static bool EnemyBattle(Fighter enemy, Fighter player, int[,] room)
        {
            Console.WriteLine(enemy.Name + " attacks " + player.Name + " with a " + enemy.Weapon.Name + "!");

            enemy.Attack(player);

            Console.WriteLine("Current Health: " + player.Health);
            Console.WriteLine("Enemy Health: " + enemy.Health);

            if (enemy.Health <= 0)
            {
                room[enemy.RowPosition, enemy.ColPosition] = 0;
                Console.WriteLine("You have defeated the " + enemy.Name);
                Console.WriteLine("---------------------");
            }

            return player.Health <= 0;
        }

        private static Fighter GetType(string type, string name, string weapon, string armor, int potion)
        {
            Fighter newFighter = null;

            switch (type)
            {
                case "Brute":
                    newFighter = new Brute(name, 10, weapon, armor, potion);
                    break;
                case "Ninja":
                    newFighter = new Ninja(name, 10, weapon, armor, potion);
                    break;
                case "Troll":
                    newFighter = new Troll(name, 10, weapon, armor, potion);
                    break;
            }

            newFighter.RowPosition = 0;
            newFighter.ColPosition = 0;

            return newFighter;
        }

        private static Fighter SetUpEnemy()
        {

            int random = rand.Next(1, 4);

            if (random == 1)
            {
                return new Brute();
            }
            else if (random == 2)
            {
                return new Ninja();
            }
            else if (random == 3)
            {
                return new Troll();
            }

            return new Brute();
        }

        private static Fighter SetUpPlayer()
        {
            Console.WriteLine("Hello warrior, let's get you set up!");
            Console.WriteLine("What shall we call you?");
            string name = Console.ReadLine();

            Console.WriteLine("Choose your fighter type: ");
            Console.WriteLine("Brute | Ninja | Troll");
            string type = Console.ReadLine();

            Console.WriteLine("Choose your Weapon: ");
            Console.WriteLine("Fists | Sword | Crossbow");
            string weapon = Console.ReadLine();

            Console.WriteLine("Choose your Armor: ");
            Console.WriteLine("Helmet | Shirt | Shield");
            string armor = Console.ReadLine();

            Console.WriteLine("Choose how many potions you want to bring: ");
            Console.WriteLine("1 | 2 | 3");
            int potion = Convert.ToInt32(Console.ReadLine());

            return GetType(type, name, weapon, armor, potion);
        }

        private static Fighter GetEnemy(int row, int col)
        {
            foreach (Fighter enemy in enemyList)
            {
                if (enemy.RowPosition == row && enemy.ColPosition == col)
                {
                    return enemy;
                }
            }
            return null;
        }

        private static void PrintBoard(int[,] board, int roomNum)
        {
            Console.WriteLine();
            Console.WriteLine("Room " + roomNum);
            Console.WriteLine("___________________");
            Console.WriteLine();
            for (int row = 0; row < 15; row++)
            {
                for (int col = 0; col < 15; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
