using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Coin : IDraw
    {
        private Image image;
        public readonly int value;
        public readonly int posX;
        public int PosY { get; set; }

        public Coin(int posX, int posY, string name)
        {
            this.posX = posX;
            this.PosY = posY;

            if (name == "Coin")
            {
                value = 1;
                image = Properties.Resources.Coin;
            }
            else if (name == "Coins")
            {
                value = 3;
                image = Properties.Resources.Coins;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new PointF(posX, PosY));
        }
    }
}
