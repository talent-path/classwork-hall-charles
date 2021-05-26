using System;
using RPG.Classes.Armor;
using RPG.Classes.Fighter;
using RPG.Classes.Weapon;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter player = SetUpPlayer();
            int points = 0;

            while (player.Health > 0)
            {
                Fighter enemy = SetUpEnemy();

                Console.WriteLine("Watch out! An enemy " + enemy.Name + " appears!");

                points = Battle(player, enemy, points);

            }

            GameOverScreen(player, points);
        }

        private static int Battle(Fighter player, Fighter enemy, int points)
        {
            Fighter attacker = player;
            Fighter defender = enemy;
            Random rand = new Random();

            while (player.Health > 0 && enemy.Health > 0)
            {
                if(attacker.Weapon.Name == "Crossbow")
                {
                    if(rand.Next(0,2) == 0)
                    {
                        attacker.Weapon.Damage = 20;
                    }
                    else
                    {
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
                points++;
            }

            return points;
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

            return newFighter;
        }

        private static Fighter SetUpEnemy()
        {
            Random rand = new Random();

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
