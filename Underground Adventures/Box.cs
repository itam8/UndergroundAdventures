using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Box : IDraw
    {
        protected Image image;
        protected int counter;
        public readonly int posX;
        public int PosY { get; set; }
        public int Health { get; protected set; }

        public Box(int posX, int posY)
        {
            this.posX = posX;
            this.PosY = posY;
            image = Properties.Resources.Box;
            counter = 0;
            Health = 2;
        }

        public virtual void Draw(Graphics g)
        {
            if (counter == 5)
            {
                counter = 0;
                image = Properties.Resources.Box;
            }
            else if (counter != 0) counter++;

            g.DrawImage(image, new PointF(posX, PosY));
        }

        public virtual void Open()
        {
            Health--;

            if (Health > 0)
            {
                image = Properties.Resources.BoxD;
                counter = 1;
            }
            else
            {
                Random rnd = new Random();
                int random = rnd.Next(3);

                Game.boxes.Remove(this);

                if (random == 0) Game.items.Add(new Item(posX, PosY, "Apple"));
                else if (random == 1) Game.items.Add(new Item(posX, PosY, "Pear"));
                else Game.coins.Add(new Coin(posX, PosY, "Coins"));
            }
        }
    }
}
