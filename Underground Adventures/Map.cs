using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public static class Map
    {
        public const int size = 64;
        public const int width = size * 11;
        public const int height = size * 15;
        public static int score = 0;
        public static int coinCounter = 0;
        public static List<Monster> monsters;
        public static List<Obstacle> obstacles;
        public static List<Background> backgrounds;
        public static List<Coin> coins;

        public static void GenerateStartMap(string map)
        {
            Random rnd = new Random();

            for(int i = 0, j = 0; j < 15; j++)
            {
                for (int k = -2; k < 11; k++)
                {
                    int x = k * size, y = j * size;

                    if (map[i] == '-')
                    {
                        int random = rnd.Next(10);
                        if (random == 0)
                        {
                            random = rnd.Next(5);

                            if(random == 0) backgrounds.Add(new Background(x, y, Properties.Resources.Background1));
                            else if (random == 1) backgrounds.Add(new Background(x, y, Properties.Resources.Background2));
                            else if (random == 2) backgrounds.Add(new Background(x, y, Properties.Resources.Background3));
                            else if (random == 3) backgrounds.Add(new Background(x, y, Properties.Resources.Background4));
                            else backgrounds.Add(new Background(x, y, Properties.Resources.Background5));
                        }
                    }
                    else if (map[i] == 'M')
                    {
                        int random = rnd.Next(4);

                        if (random == 0) monsters.Add(new Ghost(x, y));
                        else if (random == 1) monsters.Add(new Goblin(x, y));
                        else if (random == 2) monsters.Add(new Skeleton(x, y));
                        else monsters.Add(new Spider(x, y));
                    }
                    else if (map[i] == 'O')
                    {
                        int random = rnd.Next(2);

                        if (random == 0) obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle9));
                        else obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle10));
                    }
                    else if (map[i] == 'C')
                        coins.Add(new Coin(x, y, Properties.Resources.Coin));
                    else if (map[i] == '1')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle1));
                    else if (map[i] == '2')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle2));
                    else if (map[i] == '3')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle3));
                    else if (map[i] == '4')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle4));
                    else if (map[i] == '5')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle5));
                    else if (map[i] == '6')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle6));
                    else if (map[i] == '7')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle7));
                    else if (map[i] == '8')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle8));
                    else if (map[i] == '9')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle11));

                    i++;
                }
            }
        }

        public static void GenerateMap(string map)
        {
            Random rnd = new Random();

            for (int i = 0, j = -15; j < 0; j++)
            {
                for (int k = -2; k < 11; k++)
                {
                    int x = k * size, y = j * size;

                    if (map[i] == '-')
                    {
                        int random = rnd.Next(10);

                        if (random == 0)
                        {
                            random = rnd.Next(5);
                            if (random == 0) backgrounds.Add(new Background(x, y, Properties.Resources.Background1));
                            else if (random == 1) backgrounds.Add(new Background(x, y, Properties.Resources.Background2));
                            else if (random == 2) backgrounds.Add(new Background(x, y, Properties.Resources.Background3));
                            else if (random == 3) backgrounds.Add(new Background(x, y, Properties.Resources.Background4));
                            else backgrounds.Add(new Background(x, y, Properties.Resources.Background5));
                        }
                    }
                    else if (map[i] == 'M')
                    {
                        int random = rnd.Next(4);

                        if (random == 0) monsters.Add(new Ghost(x, y));
                        else if (random == 1) monsters.Add(new Goblin(x, y));
                        else if (random == 2) monsters.Add(new Skeleton(x, y));
                        else monsters.Add(new Spider(x, y));
                    }
                    else if (map[i] == 'O')
                    {
                        int random = rnd.Next(2);

                        if (random == 0) obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle9));
                        else obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle10));
                    }
                    else if (map[i] == 'C')
                        coins.Add(new Coin(x, y, Properties.Resources.Coin));
                    else if (map[i] == '1')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle1));
                    else if (map[i] == '2')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle2));
                    else if (map[i] == '3')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle3));
                    else if (map[i] == '4')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle4));
                    else if (map[i] == '5')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle5));
                    else if (map[i] == '6')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle6));
                    else if (map[i] == '7')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle7));
                    else if (map[i] == '8')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle8));
                    else if (map[i] == '9')
                        obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle11));

                    i++;
                }
            }
        }

        public static void Move()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].posY += size;
                if (monsters[i].posY > height) monsters.Remove(monsters[i]);
            }
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].posY += size;
                if (obstacles[i].posY > height) obstacles.Remove(obstacles[i]);
            }
            for (int i = 0; i < backgrounds.Count; i++)
            {
                backgrounds[i].posY += size;
                if (backgrounds[i].posY > height) backgrounds.Remove(backgrounds[i]);
            }
            for (int i = 0; i < coins.Count; i++)
            {
                coins[i].posY += size;
                if (coins[i].posY > height) coins.Remove(coins[i]);
            }
        }

        //public static string[] map1 = 
        //{
        //    "", "", "", "", "", "", "", "", "M", "O", "O",
        //    "M", "O", "O", "", "", "", "", "", "", "O", "O",
        //    "C", "O", "O", "O", "", "", "C", "", "O", "O", "C",
        //    "C", "", "", "", "O", "O", "C", "O", "O", "C", "C",
        //    "O", "O", "", "", "", "", "", "", "", "C", "O",
        //    "O", "O", "O", "", "", "", "", "", "", "C", "",
        //    "", "", "", "", "", "", "", "", "", "O", "O",
        //    "", "", "", "", "", "", "", "", "", "O", "O",
        //    "O", "O", "O", "", "", "", "", "", "", "", "O",
        //    "O", "O", "", "", "", "", "", "", "", "", "O",
        //    "O", "O", "", "", "", "", "", "", "", "O", "O",
        //    "O", "O", "", "", "O", "", "", "", "O", "", "",
        //    "O", "", "", "", "", "", "", "O", "O", "", "",
        //    "", "O", "", "", "O", "O", "O", "", "", "", "",
        //    "O", "O", "O4", "O4", "O4", "O4", "O4", "O4", "O4", "O", "O"
        //};
        public const string startMap1 = @"
--------MOO
MOO------OO
COOO--C-OOC
C---OOCOOCC
OO-------CO
OOO------C-
---------OO
---------OO
OOO-------O
OO--------O
OO-------OO
OO--O---O--
O------OO--
-O--OOO----
OO4444444OO";

        public const string map1 = @"
-------27MC
11-11117111
2-------M2-
----CCC----
--M-C7C----
11171111-11
----------O
O---OCO--OO
OO--OOO--O-
----M---OO-
OO---------
O----------
----O----O-
---OOCCC-OO
--OO-OOO--O";
    }
}
