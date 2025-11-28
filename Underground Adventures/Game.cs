using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public static class Game
    {
        public static PrivateFontCollection font;
        public const int size = 64;
        public const int width = size * 11;
        public const int height = size * 15;
        public static int score = 0;
        public static int coinCounter = 0;
        public static bool gameOver = false;
        public static List<Monster> monsters;
        public static List<Obstacle> obstacles;
        public static List<Background> backgrounds;
        public static List<Coin> coins;
        public static List<Box> boxes;
        public static List<Item> items;

        public static void Fonts()
        {
            font = new PrivateFontCollection();
            font.AddFontFile("font/LGGothic.ttf");
        }

        public static void GenerateStartMap()
        {
            Random rnd = new Random();
            int random = rnd.Next(3);
            string map;

            if (random == 0) map = startMap1;
            else if (random == 1) map = startMap2;
            else map = startMap3;

            for (int i = 0, j = 0; j < 15; j++)
            {
                for (int k = -2; k < 11; k++)
                {
                    int x = k * size, y = j * size;

                    if (map[i] == '-')
                    {
                        random = rnd.Next(12);

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
                        random = rnd.Next(4);

                        if (random == 0) monsters.Add(new Ghost(x, y));
                        else if (random == 1) monsters.Add(new Goblin(x, y));
                        else if (random == 2) monsters.Add(new Skeleton(x, y));
                        else monsters.Add(new Spider(x, y));
                    }
                    else if (map[i] == 'O')
                    {
                        random = rnd.Next(2);

                        if (random == 0) obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle9));
                        else obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle10));
                    }
                    else if (map[i] == 'C')
                        coins.Add(new Coin(x, y, "Coin"));
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

        public static void GenerateMap()
        {
            Random rnd = new Random();
            int random = rnd.Next(10);
            string map;

            if (random == 0) map = map1;
            else if (random == 1) map = map2;
            else if (random == 2) map = map3;
            else if (random == 3) map = map4;
            else if (random == 4) map = map5;
            else if (random == 5) map = map6;
            else if (random == 6) map = map7;
            else if (random == 7) map = map8;
            else if (random == 8) map = map9;
            else map = map10;

            for (int i = 0, j = -15; j < 0; j++)
            {
                for (int k = -2; k < 11; k++)
                {
                    int x = k * size, y = j * size;

                    if (map[i] == '-')
                    {
                        if (rnd.Next(12) == 0)
                        {
                            random = rnd.Next(5);

                            if (random == 0) backgrounds.Add(new Background(x, y, Properties.Resources.Background1));
                            else if (random == 1) backgrounds.Add(new Background(x, y, Properties.Resources.Background2));
                            else if (random == 2) backgrounds.Add(new Background(x, y, Properties.Resources.Background3));
                            else if (random == 3) backgrounds.Add(new Background(x, y, Properties.Resources.Background4));
                            else backgrounds.Add(new Background(x, y, Properties.Resources.Background5));
                        }
                        else if (rnd.Next(60) == 0)
                        {
                            if (rnd.Next(2) == 0) boxes.Add(new Chest(x, y));
                            else boxes.Add(new Box(x, y));
                        }
                    }
                    else if (map[i] == 'M')
                    {
                        random = rnd.Next(4);

                        if (random == 0) monsters.Add(new Ghost(x, y));
                        else if (random == 1) monsters.Add(new Goblin(x, y));
                        else if (random == 2) monsters.Add(new Skeleton(x, y));
                        else monsters.Add(new Spider(x, y));
                    }
                    else if (map[i] == 'O')
                    {
                        random = rnd.Next(2);

                        if (random == 0) obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle9));
                        else obstacles.Add(new Obstacle(x, y, Properties.Resources.Obstacle10));
                    }
                    else if (map[i] == 'C')
                        coins.Add(new Coin(x, y, "Coin"));
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
            foreach (var monster in monsters) monster.PosY += size;
            foreach (var obstacle in obstacles) obstacle.PosY += size;
            foreach (var background in backgrounds) background.PosY += size;
            foreach (var coin in coins) coin.PosY += size;
            foreach (var box in boxes) box.PosY += size;
            foreach (var item in items) item.PosY += size;

            for (int i = 0; i < monsters.Count; i++)
                if (monsters[i].PosY > height) monsters.Remove(monsters[i]);
            for (int i = 0; i < obstacles.Count; i++)
                if (obstacles[i].PosY > height) obstacles.Remove(obstacles[i]);
            for (int i = 0; i < backgrounds.Count; i++)
                if (backgrounds[i].PosY > height) backgrounds.Remove(backgrounds[i]);
            for (int i = 0; i < coins.Count; i++)
                if (coins[i].PosY > height) coins.Remove(coins[i]);
            for (int i = 0; i < boxes.Count; i++)
                if (boxes[i].PosY > height) boxes.Remove(boxes[i]);
            for (int i = 0; i < items.Count; i++)
                if (items[i].PosY > height) items.Remove(items[i]);
        }

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
        public const string startMap2 = @"
---1-------
1117------O
O---------O
--5556M1---
-C5CCCC1---
-C5MCCM1---
-C665C11---
O---------O
711-----565
OO------OOO
O--------OO
--O-OOO----
---OO-O--OO
4---------4
91117117719";
        public const string startMap3 = @"
-----------
-M-----4444
-------4CCC
OOOO---4--C
--2----4M44
---M------2
--OOO---OO-
1111-----O-
CCCC-----O-
1111-O-----
OO2--O----O
COO----O-OO
---O--O--OO
O-------OO4
OO44OOO4444";

        public const string map1 = @"
-------27MC
11--1117111
2-------M2-
----CCC----
--M-C7C----
11171111--1
----------O
O---OCO--OO
OO--OOO--O-
----M---OO-
OO---------
O----------
----O----O-
---OOCCC-OO
--OO-OOO--O";
        public const string map2 = @"
---------55
55-----5565
5655------M
--M--------
--5-----555
C56---55655
C5---------
66-------5C
5--5---M-5C
---5---5-6C
5-65---5-55
5-6-COC5--6
2MO-COC5---
--O--O-55--
-----------";
        public const string map3 = @"
-----------
44-----M444
4448----4--
----M---CCC
O------24CC
448--344444
----------M
-O---2-----
448-34448--
-----------
2---------O
OO-----3444
44448----MO
----------O
----------O";
        public const string map4 = @"
-----------
-M--1-1----
----1-1----
M---1-71111
----------C
1711--5565C
----------C
M--C1---2--
-CCC7--5655
11111--CCCC
---------M2
CCC----5555
17111-----2
2M-21------
-----------";
        public const string map5 = @"
OO-M------O
44444---OOO
CCC-------O
44O-----444
-4OO---44-M
M------4---
444----4CCC
----------C
44--44--44C
C444M----4C
C44------4C
CCC------44
-24-------M
444444--444
-----------";
        public const string map6 = @"
O---------O
OOO----OOOO
--------OOO
7711----M--
O--1C1----1
O---CC1111C
M-2----1CCC
--OOO--7C--
O------7C--
-------11--
-1------1M1
-171-------
M---11-----
-----------
----7111---";
        public const string map7 = @"
---OOO-----
------44444
-OOO--4CCCC
-CCOO-4CCCC
OOCC--4----
M-OO--4M444
-----------
OOO------OO
-----------
-O------OOO
-OO--M---OO
MO---------
--2--O-OC--
--56-O-OCO-
-----O---O-";
        public const string map8 = @"
OO---CCC--O
OO-O-OCOM-O
MOO--OOO-OO
C-OO-------
C--------OO
CO----O---O
OO---MOO---
O--OOOOOO--
-----O-----
OO-----OOO-
OO--C--OOOM
COO-C-OO---
CCOOCOO----
CC-------OO
OO--------O";
        public const string map9 = @"
-----------
OO--------O
O---MOO---O
CCC-OOOO---
CCCOOOOO--M
OO--OOOCCOO
OO---OOCCOO
OOO---M-OOO
OOOO-----OO
---O--OO---
CCCC-CCCCOO
-OMO---OOOO
---------OO
OOO--O--M-O
-----------";
        public const string map10 = @"
-----------
O4442---444
494448CC-OO
-9CC48CC-M-
CCC48-CC-44
CCC4M----99
44C4---4299
M------9499
-4-4-24948-
-944-448CCC
-9---48CCCM
44M--48CC-3
OOO-----O34
444---34444
-----------";
    }
}
