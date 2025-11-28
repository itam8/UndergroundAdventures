using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public interface IEnemy
    {
        void Draw(Graphics g);
    }

    public abstract class Monster
    {
        public Image image;
        public int posX;
        public int posY;
        public int currentFrame;
        public int health;
        public int damage;

        public Monster(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            currentFrame = 0;
        }

        public abstract void TakeDamage(Player player);
    }
}
