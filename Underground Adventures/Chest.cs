using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Chest : Box
    {
        public bool PlayerIsNearby { get; set; }

        public Chest(int posX, int posY) : base(posX, posY)
        {
            image = Properties.Resources.Chest;
            PlayerIsNearby = false;
        }

        public override void Draw(Graphics g)
        {
            if (counter == 5)
            {
                counter = 0;
                image = Properties.Resources.ChestO;
            }
            else if (counter != 0) counter++;

            if (PlayerIsNearby && Health == 2)
                g.DrawString("Pay 20 coins?", new Font(Game.font.Families[0], 16), new SolidBrush(Color.FromArgb(235, 59, 103)), new PointF(posX - 32, PosY - 20));

            g.DrawImage(image, new PointF(posX, PosY));
        }

        public override void Open()
        {
            if (Game.coinCounter >= 20 && Health == 2) Health--;

            if (Health == 1)
            {
                image = Properties.Resources.ChestO;
                counter = 1;
                Game.coinCounter -= 20;
                Health--;
            }
            else if (Health == 0)
            {
                Random rnd = new Random();

                Game.boxes.Remove(this);

                if (rnd.Next(2) == 0) Game.items.Add(new Item(posX, PosY, "Armor"));
                else Game.items.Add(new Item(posX, PosY, "Sword"));
            }
        }
    }
}
