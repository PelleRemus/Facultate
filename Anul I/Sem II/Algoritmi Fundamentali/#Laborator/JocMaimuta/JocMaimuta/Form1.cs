using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JocMaimuta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.InitGame(this);
            timer1.Start();
            timer2.Start();
        }

        bool left, right, up, down;
        int count = 0;
        Banana B;
        Image banana = Image.FromFile(@"../../Resurse/banana.png");

        private void timer2_Tick(object sender, EventArgs e)
        {
            count++;
            int a = Engine.r.Next(4);
            int x = 0, y = 0;
            switch(a)
            {
                case 0:
                    if (Engine.computer.x > 0)
                        Engine.computer.x -= Engine.computer.speed;
                    if (count == 5)
                    {
                        count = 0;
                        x = Engine.computer.x - 30;
                        y = Engine.computer.y + 50;
                        B = new Banana(new Point(x, y), this, banana, "left");
                    }
                    break;
                case 1:
                    if (Engine.computer.x < 752)
                        Engine.computer.x += Engine.computer.speed;
                    if (count == 5)
                    {
                        count = 0;
                        x = Engine.computer.x + 100;
                        y = Engine.computer.y + 50;
                        B = new Banana(new Point(x, y), this, banana, "right");
                    }
                    break;
                case 2:
                    if (Engine.computer.y > 0)
                        Engine.computer.y -= Engine.computer.speed;
                    if (count == 5)
                    {
                        count = 0;
                        x = Engine.computer.x + 50;
                        y = Engine.computer.y - 30;
                        B = new Banana(new Point(x, y), this, banana, "up");
                    }
                    break;
                case 3:
                    if (Engine.computer.y < 350)
                        Engine.computer.y += Engine.computer.speed;
                    if (count == 5)
                    {
                        count = 0;
                        x = Engine.computer.x + 50;
                        y = Engine.computer.y + 100;
                        B = new Banana(new Point(x, y), this, banana, "down");
                    }
                    break;
            }
            Engine.computer.Draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Check(this);
            label1.Text = "Lives: " + Engine.player.health;
            label2.Text = "Lives: " + Engine.computer.health;
            if (Engine.player.health <= 0)
            {
                Invalidate();
                Engine.player.monkey.Dispose();
                timer1.Stop();
                timer2.Stop();
            }
            if (Engine.computer.health <= 0)
            {
                Invalidate();
                Engine.computer.monkey.Dispose();
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Banana b;
            if (e.KeyCode == Keys.Left)
            {
                if (Engine.player.x > 0)
                    Engine.player.x -= Engine.player.speed;
                left = true; right = up = down = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (Engine.player.x < 752)
                    Engine.player.x += Engine.player.speed;
                right = true; left = up = down = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (Engine.player.y > 0)
                    Engine.player.y -= Engine.player.speed;
                up = true; left = right = down = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (Engine.player.y < 350)
                    Engine.player.y += Engine.player.speed;
                down = true; left = right = up = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                int x = 0, y = 0;
                string s = "";
                if (left == true)
                {
                    s = "left";
                    x = Engine.player.x - 30;
                    y = Engine.player.y + 50;
                }
                if (right == true)
                {
                    s = "right";
                    x = Engine.player.x + 100;
                    y = Engine.player.y + 50;
                }
                if (up == true)
                {
                    s = "up";
                    x = Engine.player.x + 50;
                    y = Engine.player.y - 30;
                }
                if (down == true)
                {
                    s = "down";
                    x = Engine.player.x + 50;
                    y = Engine.player.y + 100;
                }
                b = new Banana(new Point(x, y), this, banana, s);
            }
            Engine.player.Draw();
        }
    }
}
