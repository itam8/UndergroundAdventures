using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Player : IDraw
    {
        private Image image;
        private int currentFrame;
        private bool flip;
        private bool attack;
        private int direction;
        private int counter;
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Health { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Damage { get; private set; }

        public Player()
        {
            image = Properties.Resources.WarriorL;
            PosX = Game.size * 5;
            PosY = Game.size * 8;
            currentFrame = 0;
            flip = false;
            attack = false;
            direction = 0;
            counter = 0;
            Health = 50;
            CurrentHealth = 50;
            Damage = 2;
        }

        public void Draw(Graphics g)
        {
            if (currentFrame == 0)
            {
                if (flip) image = Properties.Resources.WarriorR;
                else image = Properties.Resources.WarriorL;
                currentFrame++;
            }
            else if (currentFrame == 2)
            {
                if (flip) image = Properties.Resources.WarriorR1;
                else image = Properties.Resources.WarriorL1;
                currentFrame++;
            }
            else if (currentFrame == 5)
            {
                if (flip) image = Properties.Resources.WarriorR;
                else image = Properties.Resources.WarriorL;
                currentFrame++;
            }
            else if (currentFrame == 7)
            {
                if (flip) image = Properties.Resources.WarriorR2;
                else image = Properties.Resources.WarriorL2;
                currentFrame = -2;
            }
            else currentFrame++;

            if (attack) Attack();
            
            g.DrawImage(image, new PointF(PosX, PosY));
        }

        public void Attack()
        {
            if (attack && counter == 0)
            {
                if (direction == 1) PosY -= Game.size / 4;
                else if (direction == 2) PosY += Game.size / 4;
                else if (direction == 3) PosX -= Game.size / 4;
                else PosX += Game.size / 4;

                counter++;
            }
            else if (counter == 3)
            {
                if (direction == 1) PosY += Game.size / 4;
                else if (direction == 2) PosY -= Game.size / 4;
                else if (direction == 3) PosX += Game.size / 4;
                else PosX -= Game.size / 4;

                attack = false;
                counter = 0;
            }
            else if (attack) counter++;
        }

        public void TakeDamage(Monster monster)
        {
            CurrentHealth -= monster.Damage;

            if (CurrentHealth > 0)
            {
                if (flip) image = Properties.Resources.WarriorRD;
                else image = Properties.Resources.WarriorLD;
                currentFrame = -6;
            }
            else Game.gameOver = true;
        }

        public void GoUp()
        {
            bool flag = false;

            foreach (var obstacle in Game.obstacles)
            {
                if (obstacle.posX == PosX && obstacle.PosY == PosY - Game.size)
                {
                    flag = true;
                    break;
                }
            }
            foreach (var monster in Game.monsters)
            {
                if (monster.PosX == PosX && monster.PosY == PosY - Game.size)
                {
                    monster.TakeDamage(this);
                    attack = true;
                    direction = 1;
                    flag = true;
                    break;
                }
            }
            foreach (var box in Game.boxes)
            {
                if (box.posX == PosX && box.PosY == PosY - Game.size)
                {
                    box.Open();
                    attack = true;
                    direction = 1;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                if (PosY == Game.size * 8)
                {
                    if (Game.score % 15 == 0) Game.GenerateMap();
                    Game.Move();
                    Game.score++;
                }
                else PosY -= Game.size;
            }
        }

        public void GoDown()
        {
            bool flag = false;

            foreach (var obstacle in Game.obstacles)
            {
                if (obstacle.posX == PosX && obstacle.PosY == PosY + Game.size)
                {
                    flag = true;
                    break;
                }
            }
            foreach (var monster in Game.monsters)
            {
                if (monster.PosX == PosX && monster.PosY == PosY + Game.size)
                {
                    monster.TakeDamage(this);
                    attack = true;
                    direction = 2;
                    flag = true;
                    break;
                }
            }
            foreach (var box in Game.boxes)
            {
                if (box.posX == PosX && box.PosY == PosY + Game.size)
                {
                    box.Open();
                    attack = true;
                    direction = 2;
                    flag = true;
                    break;
                }
            }

            if (!flag && PosY < Game.height - Game.size) PosY += Game.size;
        }

        public void GoLeft()
        {
            bool flag = false;

            foreach (var obstacle in Game.obstacles)
            {
                if (obstacle.PosY == PosY && obstacle.posX == PosX - Game.size)
                {
                    flag = true;
                    break;
                }
            }
            foreach (var monster in Game.monsters)
            {
                if (monster.PosY == PosY && monster.PosX == PosX - Game.size)
                {
                    monster.TakeDamage(this);
                    attack = true;
                    direction = 3;
                    flag = true;
                    break;
                }
            }
            foreach (var box in Game.boxes)
            {
                if (box.PosY == PosY && box.posX == PosX - Game.size)
                {
                    box.Open();
                    attack = true;
                    direction = 3;
                    flag = true;
                    break;
                }
            }

            if (!flag && PosX > 0) PosX -= Game.size;

            if (flip)
            {
                image = Properties.Resources.WarriorL;
                flip = false;
            }
        }

        public void GoRight()
        {
            bool flag = false;

            foreach (var obstacle in Game.obstacles)
            {
                if (obstacle.PosY == PosY && obstacle.posX == PosX + Game.size)
                {
                    flag = true;
                    break;
                }
            }
            foreach (var monster in Game.monsters)
            {
                if (monster.PosY == PosY && monster.PosX == PosX + Game.size)
                {
                    monster.TakeDamage(this);
                    attack = true;
                    direction = 4;
                    flag = true;
                    break;
                }
            }
            foreach (var box in Game.boxes)
            {
                if (box.PosY == PosY && box.posX == PosX + Game.size)
                {
                    box.Open();
                    attack = true;
                    direction = 4;
                    flag = true;
                    break;
                }
            }

            if (!flag && PosX < Game.width - Game.size) PosX += Game.size;

            if (!flip)
            {
                image = Properties.Resources.WarriorR;
                flip = true;
            }
        }

        public void Boost(Item item)
        {
            if (item.name == "Apple")
            {
                if (Health - CurrentHealth >= 20) CurrentHealth += 20;
                else CurrentHealth += Health - CurrentHealth;
            }
            else if (item.name == "Pear")
            {
                if (Health - CurrentHealth >= 15) CurrentHealth += 15;
                else CurrentHealth += Health - CurrentHealth;
            }
            else if (item.name == "Armor")
            {
                CurrentHealth = (int)((Health + 20) * ((double)CurrentHealth / Health));
                Health += 20;
            }
            else if (item.name == "Sword") Damage++;
        }
    }
}
