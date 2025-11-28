using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Skeleton : Monster
    {
        private bool flip;

        public Skeleton(int posX, int posY) : base(posX, posY)
        {
            image = Properties.Resources.SkeletonL;
            flip = false;
            Health = 5;
            Damage = 2;
            Health += Game.score / 40 + 1;
            Damage += Game.score / 40;
            CurrentHealth = Health;
        }

        public override void Draw(Graphics g)
        {

            if (currentFrame == 0)
            {
                if (flip) image = Properties.Resources.SkeletonR;
                else image = Properties.Resources.SkeletonL;
                currentFrame++;
            }
            else if (currentFrame == 2)
            {
                if (flip) image = Properties.Resources.SkeletonR1;
                else image = Properties.Resources.SkeletonL1;
                currentFrame++;
            }
            else if (currentFrame == 5)
            {
                if (flip) image = Properties.Resources.SkeletonR;
                else image = Properties.Resources.SkeletonL;
                currentFrame++;
            }
            else if (currentFrame == 7)
            {
                if (flip) image = Properties.Resources.SkeletonR2;
                else image = Properties.Resources.SkeletonL2;
                currentFrame = -2;
            }
            else currentFrame++;

            if (PlayerIsNearby)
                g.DrawString(CurrentHealth.ToString() + "/" + Health.ToString(), new Font(Game.font.Families[0], 16), new SolidBrush(Color.FromArgb(235, 59, 103)), new PointF(PosX + 12, PosY - 20));

            if (attack) Attack();

            g.DrawImage(image, new PointF(PosX, PosY));
        }

        public override void TakeDamage(Player player)
        {
            CurrentHealth -= player.Damage;

            if (CurrentHealth > 0)
            {
                if (flip) image = Properties.Resources.SkeletonRD;
                else image = Properties.Resources.SkeletonLD;
                currentFrame = -6;
            }
            else Game.monsters.Remove(this);
        }

        public override void Move(Player player)
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
                flip = false;
            }
            else if (player.PosY == PosY && player.PosX == PosX + Game.size)
            {
                player.TakeDamage(this);
                attack = true;
                direction = 4;
                flip = true;
            }
            else if (Math.Abs(player.PosY - PosY) < 5 * Game.size && Math.Abs(player.PosX - PosX) < 5 * Game.size)
            {
                direction = rnd.Next(2);

                if (PosX > player.PosX && PosY < player.PosY)
                {
                    if (direction == 0 && !flag3 && PosX > 0)
                    {
                        PosX -= Game.size;
                        direction = 3;
                    }
                    else if (!flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                }
                else if (PosX < player.PosX && PosY < player.PosY)
                {
                    if (direction == 0 && !flag4 && PosX < Game.width - Game.size)
                    {
                        PosX += Game.size;
                        direction = 4;
                    }
                    else if (!flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                }
                else if (PosX < player.PosX && PosY > player.PosY)
                {
                    if (direction == 0 && !flag4 && PosX < Game.width - Game.size)
                    {
                        PosX += Game.size;
                        direction = 4;
                    }
                    else if (!flag1) PosY -= Game.size;
                }
                else if (PosX > player.PosX && PosY > player.PosY)
                {
                    if (direction == 0 && !flag3 && PosX > 0)
                    {
                        PosX -= Game.size;
                        direction = 3;
                    }
                    else if (!flag1) PosY -= Game.size;
                }
                else if (PosY > player.PosY && !flag1)
                {
                    PosY -= Game.size;
                    direction = 1;
                }
                else if (PosY < player.PosY && !flag2 && PosY < Game.height - Game.size)
                {
                    PosY += Game.size;
                    direction = 2;
                }
                else if (PosX > player.PosX && !flag3 && PosX > 0)
                {
                    PosX -= Game.size;
                    direction = 3;
                }
                else if (PosX < player.PosX && !flag4 && PosX < Game.width - Game.size)
                {
                    PosX += Game.size;
                    direction = 4;
                }
            }
            else
            {
                direction = rnd.Next(1, 5);

                if (direction == 1 && !flag1) PosY -= Game.size;
                else if (direction == 2 && !flag2 && PosY < Game.height - Game.size) PosY += Game.size;
                else if (direction == 3 && !flag3 && PosX > 0) PosX -= Game.size;
                else if (!flag4 && PosX < Game.width - Game.size) PosX += Game.size;
            }

            if (flip && direction == 3)
            {
                image = Properties.Resources.SkeletonL;
                flip = false;
            }
            else if (!flip && direction == 4)
            {
                image = Properties.Resources.SkeletonR;
                flip = true;
            }
        }
    }
}
