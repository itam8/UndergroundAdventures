using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public abstract class Monster : IDraw
    {
        protected Image image;
        protected int currentFrame;
        protected bool attack;
        protected int direction;
        protected int counter;
        public bool PlayerIsNearby { get; set; }
        public int PosX { get; protected set; }
        public int PosY { get; set; }
        public int Health { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Damage { get; protected set; }

        public Monster(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
            currentFrame = 0;
            attack = false;
            direction = 0;
            counter = 0;
            PlayerIsNearby = false;
        }

        public virtual void Draw(Graphics g) { }

        public abstract void TakeDamage(Player player);

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

        public virtual void Move(Player player)
        {
            Random rnd = new Random();
            bool flag1 = false, flag2 = false, flag3 = false, flag4 = false;

            foreach (var obstacle in Game.obstacles)
            {
                if (obstacle.posX == PosX && obstacle.PosY == PosY - Game.size) flag1 = true;
                else if (obstacle.posX == PosX && obstacle.PosY == PosY + Game.size) flag2 = true;
                else if (obstacle.PosY == PosY && obstacle.posX == PosX - Game.size) flag3 = true;
                else if (obstacle.PosY == PosY && obstacle.posX == PosX + Game.size) flag4 = true;
            }
            foreach (var monster in Game.monsters)
            {
                if (monster.PosX == PosX && monster.PosY == PosY - Game.size) flag1 = true;
                else if (monster.PosX == PosX && monster.PosY == PosY + Game.size) flag2 = true;
                else if (monster.PosY == PosY && monster.PosX == PosX - Game.size) flag3 = true;
                else if (monster.PosY == PosY && monster.PosX == PosX + Game.size) flag4 = true;
            }
            foreach (var box in Game.boxes)
            {
                if (box.posX == PosX && box.PosY == PosY - Game.size) flag1 = true;
                else if (box.posX == PosX && box.PosY == PosY + Game.size) flag2 = true;
                else if (box.PosY == PosY && box.posX == PosX - Game.size) flag3 = true;
                else if (box.PosY == PosY && box.posX == PosX + Game.size) flag4 = true;
            }

            if (player.PosX == PosX && player.PosY == PosY - Game.size)
            {
                player.TakeDamage(this);
                attack = true;
                direction = 1;
            }
            else if (player.PosX == PosX && player.PosY == PosY + Game.size)
            {
                player.TakeDamage(this);
                attack = true;
                direction = 2;
            }
            else if (player.PosY == PosY && player.PosX == PosX - Game.size)
            {
                player.TakeDamage(this);
                attack = true;
                direction = 3;
            }
            else if (player.PosY == PosY && player.PosX == PosX + Game.size)
            {
                player.TakeDamage(this);
                attack = true;
                direction = 4;
            }
            else if (Math.Abs(player.PosY - PosY) < 5 * Game.size && Math.Abs(player.PosX - PosX) < 5 * Game.size)
            {
                direction = rnd.Next(2);

                if (PosX > player.PosX && PosY < player.PosY)
                {
                    if (direction == 0 && !flag3 && PosX > 0) PosX -= Game.size;
                    else if (!flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                }
                else if (PosX < player.PosX && PosY < player.PosY)
                {
                    if (direction == 0 && !flag4 && PosX < Game.width - Game.size) PosX += Game.size;
                    else if (!flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                }
                else if (PosX < player.PosX && PosY > player.PosY)
                {
                    if (direction == 0 && !flag4 && PosX < Game.width - Game.size) PosX += Game.size;
                    else if (!flag1) PosY -= Game.size;
                }
                else if (PosX > player.PosX && PosY > player.PosY)
                {
                    if (direction == 0 && !flag3 && PosX > 0) PosX -= Game.size;
                    else if (!flag1) PosY -= Game.size;
                }
                else if (PosY > player.PosY && !flag1) PosY -= Game.size;
                else if (PosY < player.PosY && !flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                else if (PosX > player.PosX && !flag3 && PosX > 0) PosX -= Game.size;
                else if (PosX < player.PosX && !flag4 && PosX < Game.width - Game.size) PosX += Game.size;
            }
            else
            {
                direction = rnd.Next(1, 5);

                if (direction == 1 && !flag1) PosY -= Game.size;
                else if (direction == 2 && !flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                else if (direction == 3 && !flag3 && PosX > 0) PosX -= Game.size;
                else if (!flag4 && PosX < Game.width - Game.size) PosX += Game.size;
            }
        }
    }
}
