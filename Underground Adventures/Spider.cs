using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Spider : Monster
    {
        public Spider(int posX, int posY) : base(posX, posY)
        {
            image = Properties.Resources.Spider;
            Health = 3;
            Damage = 1;
            Health += Game.score / 40 + 1;
            Damage += Game.score / 40;
            CurrentHealth = Health;
        }

        public override void Draw(Graphics g)
        {
            if (currentFrame == 0)
            {
                image = Properties.Resources.Spider;
                currentFrame++;
            }
            else if (currentFrame == 2)
            {
                image = Properties.Resources.Spider1;
                currentFrame++;
            }
            else if (currentFrame == 5)
            {
                image = Properties.Resources.Spider;
                currentFrame++;
            }
            else if (currentFrame == 7)
            {
                image = Properties.Resources.Spider2;
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
                image = Properties.Resources.SpiderD;
                currentFrame = -6;
            }
            else Game.monsters.Remove(this);
        }
    }
}
