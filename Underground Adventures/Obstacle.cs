using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Obstacle : IDraw
    {
        private Image image;
        public readonly int posX;
        public int PosY { get; set; }

        public Obstacle(int posX, int posY, Image image)
        {
            this.posX = posX;
            this.PosY = posY;
            this.image = image;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new PointF(posX, PosY));
        }
    }
}
