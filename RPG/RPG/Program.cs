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
            int points = 0;
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
                    playerDefeated = Move(input, player, room);

                    //Check if the player has reached the exit
                    if (RoomComplete(player))
                    {
                        Console.WriteLine("Congrats! You got past room " + roomNum);
                        player.RowPosition = 0;
                        player.ColPosition = 0;
                        roomComplete = true;
                        roomNum++;
                        break;
                    }

                    //Move enemies
                    playerDefeated = EnemyMove(player, room);

                    if(playerDefeated)
                    {
                        break;
                    }
                }
                //Added because for some reason despite player defeated == true, does not break while loop??
                if(playerDefeated == true)
                {
                    break;
                }
            }

            if(playerDefeated)
            {
                Console.WriteLine("You have been defeated!");
                GameOverScreen(player, points);
            }
            else
            {
                Console.WriteLine("You have won!");
                GameOverScreen(player, points);
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

        private static Boolean RoomComplete(Fighter fighter)
        {
            return fighter.RowPosition == 14 && fighter.ColPosition == 14;
        }

        private static bool Move(char direction, Fighter fighter, int[,] room)
        {

            bool valid = true;
            bool playerDefeated = false;

            //If the position is not empty (enemy is there)
            if((fighter.RowPosition != 0 && direction == 'w' && room[fighter.RowPosition - 1, fighter.ColPosition] != 0)
                || (fighter.RowPosition != 14 && direction == 's' && room[fighter.RowPosition + 1, fighter.ColPosition] != 0)
                || (fighter.ColPosition != 0 && direction == 'a' && room[fighter.RowPosition, fighter.ColPosition - 1] != 0)
                || (fighter.ColPosition != 14 && direction == 'd' && room[fighter.RowPosition, fighter.ColPosition + 1] != 0))
            {
                //Battle
                playerDefeated = Battle(fighter, direction, room);
            }

            if (playerDefeated)
            {
                return playerDefeated;
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
            else//Else if not valid error message
            {
                Console.WriteLine("ERROR: You cannot move there!!");
            }

            return playerDefeated;
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

                    //If the column difference is greater than row, move left/right
                    if (Math.Abs(colDiff) > Math.Abs(rowDiff))
                    {
                        //Negative difference, means player is to the right
                        if (colDiff < 0)
                        {
                            //If the spot the enemy is about to move to is taken by the player battle
                            if (room[enemy.RowPosition, enemy.ColPosition + 1] == 2)
                            {
                                playerDefeated = EnemyBattle(enemy, player, room);
                            }

                            if (enemy.Health > 0)
                            {
                                room[enemy.RowPosition, enemy.ColPosition + 1] = 1;
                                room[enemy.RowPosition, enemy.ColPosition] = 0;
                                enemy.ColPosition += 1;
                            }
                        }
                        else if (colDiff > 0)//Positive difference, means player is to the left
                        {
                            if (room[enemy.RowPosition, enemy.ColPosition - 1] == 2)
                            {
                                playerDefeated = EnemyBattle(enemy, player, room);
                            }

                            if (enemy.Health > 0)
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
                        if (rowDiff < 0)
                        {
                            if (room[enemy.RowPosition + 1, enemy.ColPosition] == 2)
                            {
                                playerDefeated = EnemyBattle(enemy, player, room);
                            }

                            if (enemy.Health > 0)
                            {
                                room[enemy.RowPosition + 1, enemy.ColPosition] = 1;
                                room[enemy.RowPosition, enemy.ColPosition] = 0;
                                enemy.RowPosition += 1;
                            }
                        }
                        else if (rowDiff > 0)//Positive difference, means player is up
                        {
                            if (room[enemy.RowPosition - 1, enemy.ColPosition] == 2)
                            {
                                playerDefeated = EnemyBattle(enemy, player, room);
                            }

                            if (enemy.Health > 0)
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

        private static void PrintBoard(int[,] board, int roomNum)
        {
            Console.WriteLine();
            Console.WriteLine("Room " + roomNum);
            Console.WriteLine("___________________");
            Console.WriteLine();
            for (int row = 0; row < 15; row++)
            {
                for(int col = 0; col < 15; col++)
                {
                    Console.Write(board[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static Fighter GetEnemy(int row, int col)
        {
            foreach(Fighter enemy in enemyList)
            {
                if(enemy.RowPosition == row && enemy.ColPosition == col)
                {
                    return enemy;
                }
            }
            return null;
        }

        private static bool EnemyBattle(Fighter enemy, Fighter player, int[,] room)
        {
            Fighter attacker = player;
            Fighter defender = enemy;
            bool playerDefeated = false;

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine(attacker.Name + " attacks " + defender.Name + " with a " + attacker.Weapon.Name + "!");

                if (attacker.Weapon.Name == "Crossbow")
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("The crossbow actually hit!");
                        attacker.Weapon.Damage = 20;
                    }
                    else
                    {
                        Console.WriteLine("The crossbow missed!");
                        attacker.Weapon.Damage = 0;
                    }
                }

                attacker.Attack(defender);

                if (defender.Name == player.Name && player.Health <= 6 && player.Potion > 0)
                {
                    Console.WriteLine("You healed 4 hp with a potion!");
                    player.Health += 4;
                    player.Potion--;
                }

                if (attacker.Name == "Troll")
                {
                    Console.WriteLine("The dang troll regenerated 1 hp!");
                    attacker.Health += 1;
                }

                Fighter temp = attacker;
                attacker = defender;
                defender = temp;

                Console.WriteLine("Current Health: " + player.Health);
                Console.WriteLine("Enemy Health: " + enemy.Health);
            }

            if (enemy.Health <= 0)
            {
                Console.WriteLine("You have defeated the " + enemy.Name);
                Console.WriteLine("---------------------");
            }

            if (player.Health <= 0)
            {
                playerDefeated = true;
            }

            return playerDefeated;
        }

        private static bool Battle(Fighter player, char direction, int[,] room)
        {
            Fighter attacker = player;
            int enemyCol = 0, enemyRow = 0;

            if(direction == 'w')
            {
                enemyCol = player.ColPosition;
                enemyRow = player.RowPosition - 1;
            }
            if(direction == 'a')
            {
                enemyCol = player.ColPosition - 1;
                enemyRow = player.RowPosition;
            }
            if(direction == 's')
            {
                enemyCol = player.ColPosition;
                enemyRow = player.RowPosition + 1;
            }
            if(direction == 'd')
            {
                enemyCol = player.ColPosition + 1;
                enemyRow = player.RowPosition;
            }

            Fighter enemy = GetEnemy(enemyRow, enemyCol);
            Fighter defender = enemy;
            bool playerDefeated = false;

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine(attacker.Name + " attacks " + defender.Name + " with a " + attacker.Weapon.Name + "!");

                if (attacker.Weapon.Name == "Crossbow")
                {
                    if(rand.Next(0,2) == 0)
                    {
                        Console.WriteLine("The crossbow actually hit!");
                        attacker.Weapon.Damage = 20;
                    }
                    else
                    {
                        Console.WriteLine("The crossbow missed!");
                        attacker.Weapon.Damage = 0;
                    }
                }

                attacker.Attack(defender);

                if(defender.Name == player.Name && player.Health <= 6 && player.Potion > 0)
                {
                    Console.WriteLine("You healed 4 hp with a potion!");
                    player.Health += 4;
                    player.Potion--;
                }

                if (attacker.Name == "Troll")
                {
                    Console.WriteLine("The dang troll regenerated 1 hp!");
                    attacker.Health += 1;
                }

                Fighter temp = attacker;
                attacker = defender;
                defender = temp;

                Console.WriteLine("Current Health: " + player.Health);
                Console.WriteLine("Enemy Health: " + enemy.Health);
            }

            if(enemy.Health <= 0)
            {
                Console.WriteLine("You have defeated the " + enemy.Name);
                Console.WriteLine("---------------------");
            }

            if(player.Health <= 0)
            {
                playerDefeated = true;
            }

            return playerDefeated;
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

        private static void GameOverScreen(Fighter player, int points)
        {
            Console.WriteLine("\nGAME OVER");
            if (points == 0)
            {
                Console.WriteLine("Impressive, " + player.Name + ", you managed to kill absolutely " + points + " enemies.");
            }
            else if (points == 1)
            {
                Console.WriteLine("Uh, " + player.Name + ", you only killed " + points + " enemy. Disappointing performance.");
            }
            else
            {
                Console.WriteLine("Congratulations, " + player.Name + ", you defeated " + points + " enemies.");
            }
        }
    }
}
