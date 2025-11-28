using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underground_Adventures
{
    public class Background : IDraw
    {
        private Image image;
        private int posX;
        public int PosY { get; set; }

        public Background(int posX, int posY, Image image)
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
