using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Underground_Adventures
{
    public partial class Form1 : Form
    {
        Player player;

        public Form1()
        {
            InitializeComponent();
            Init();
            fonts();
            
            timer1.Interval = 60;
            timer1.Tick += new EventHandler(Update);
            KeyUp += new KeyEventHandler(OnPress);
            Paint += new PaintEventHandler(OnPaint);
        }

        public void Init()
        {
            Game.monsters = new List<Monster>();
            Game.obstacles = new List<Obstacle>();
            Game.backgrounds = new List<Background>();
            Game.coins = new List<Coin>();
            Game.boxes = new List<Box>();
            Game.items = new List<Item>();
            player = new Player();
            
            Game.GenerateStartMap();
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            label1.Text = player.CurrentHealth.ToString() + "/" + player.Health.ToString();
            label2.Text = Game.score.ToString();
            label3.Text = Game.coinCounter.ToString();
            label4.Text = player.Damage.ToString();

            if (Game.gameOver)
            {
                timer1.Stop();
                label5.Visible = true;
            }

            Invalidate();
        }

        private void fonts()
        {
            Game.Fonts();
            
            label1.Font = new Font(Game.font.Families[0], 20);
            label2.Font = new Font(Game.font.Families[0], 40);
            label3.Font = new Font(Game.font.Families[0], 25);
            label4.Font = new Font(Game.font.Families[0], 25);
            label5.Font = new Font(Game.font.Families[0], 60);
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player.GoUp();
                    foreach (var monster in Game.monsters)
                    {
                        if (monster.PosY >= 0) monster.Move(player);
                        if (Math.Abs(monster.PosX - player.PosX) + Math.Abs(monster.PosY - player.PosY) == Game.size) monster.PlayerIsNearby = true;
                        else monster.PlayerIsNearby = false;
                    }
                    break;
                case Keys.S:
                    player.GoDown();
                    foreach (var monster in Game.monsters)
                    {
                        if (monster.PosY >= 0) monster.Move(player);
                        if (Math.Abs(monster.PosX - player.PosX) + Math.Abs(monster.PosY - player.PosY) == Game.size) monster.PlayerIsNearby = true;
                        else monster.PlayerIsNearby = false;
                    }
                    break;
                case Keys.A:
                    player.GoLeft();
                    foreach (var monster in Game.monsters)
                    {
                        if (monster.PosY >= 0) monster.Move(player);
                        if (Math.Abs(monster.PosX - player.PosX) + Math.Abs(monster.PosY - player.PosY) == Game.size) monster.PlayerIsNearby = true;
                        else monster.PlayerIsNearby = false;
                    }
                    break;
                case Keys.D:
                    player.GoRight();
                    foreach (var monster in Game.monsters)
                    {
                        if (monster.PosY >= 0) monster.Move(player);
                        if (Math.Abs(monster.PosX - player.PosX) + Math.Abs(monster.PosY - player.PosY) == Game.size) monster.PlayerIsNearby = true;
                        else monster.PlayerIsNearby = false;
                    }
                    break;
                case Keys.Space:
                    foreach (var monster in Game.monsters)
                    {
                        if (monster.PosY >= 0) monster.Move(player);
                        if (Math.Abs(monster.PosX - player.PosX) + Math.Abs(monster.PosY - player.PosY) == Game.size) monster.PlayerIsNearby = true;
                        else monster.PlayerIsNearby = false;
                    }
                    break;
            }

            foreach (var coin in Game.coins)
            {
                if (coin.posX == player.PosX && coin.PosY == player.PosY)
                {
                    Game.coinCounter += coin.value;
                    Game.coins.Remove(coin);
                    break;
                }
            }
            foreach (var item in Game.items)
            {
                if (item.posX == player.PosX && item.PosY == player.PosY)
                {
                    player.Boost(item);
                    Game.items.Remove(item);
                    break;
                }
            }
            foreach (var chest in Game.boxes)
            {
                if (chest is Chest c)
                {
                    if (Math.Abs(chest.posX - player.PosX) + Math.Abs(chest.PosY - player.PosY) == Game.size)
                    {
                        c.PlayerIsNearby = true;
                    }
                    else c.PlayerIsNearby = false;
                }
            }

            pictureBox3.Width = (int)(424 * (double)player.CurrentHealth / player.Health);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            foreach (var coin in Game.coins) coin.Draw(g);
            foreach (var obstacle in Game.obstacles) obstacle.Draw(g);
            foreach (var background in Game.backgrounds) background.Draw(g);
            foreach (var box in Game.boxes) box.Draw(g);
            foreach (var item in Game.items) item.Draw(g);
            player.Draw(g);
            foreach (var monster in Game.monsters) monster.Draw(g);
        }
    }
}
