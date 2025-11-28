using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Item : IDraw
    {
        private Image image;

        public readonly string name;
        public readonly int posX;
        public int PosY { get; set; }

        public Item(int posX, int posY, string name)
        {
            this.posX = posX;
            this.PosY = posY;
            this.name = name;

            if (name == "Apple") image = Properties.Resources.Apple;
            else if (name == "Pear") image = Properties.Resources.Pear;
            else if (name == "Armor") image = Properties.Resources.Armor;
            else if (name == "Sword") image = Properties.Resources.Sword;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new PointF(posX, PosY));
        }
    }
}
